using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TomLabs.PowerClam;
using TomLabs.PSMaster.App.Data;
using TomLabs.PSMaster.App.Extensions;

namespace TomLabs.PSMaster.App.Forms
{
	public partial class MainForm : Form
	{
		private List<PSScipt> Scripts { get; set; } = new List<PSScipt>();

		public MainForm(string[] args)
		{
			if (args.Length > 0)
			{
				RunScript(Path.GetFileNameWithoutExtension(args[0]), args[0]);
				Close();
			}

			InitializeComponent();

			ImageList iList = new ImageList();
			iList.ImageSize = new Size(64, 64);
			iList.ColorDepth = ColorDepth.Depth32Bit;
			iList.Images.Add("default", Image.FromFile(AppDomain.CurrentDomain.BaseDirectory + "\\Images\\script-icon.png"));
			listScriptIcons.LargeImageList = iList;
		}

		private void listScriptIcons_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}

		private void listScriptIcons_DragDrop(object sender, DragEventArgs e)
		{
			string[] scripts = (string[])e.Data.GetData(DataFormats.FileDrop);
			foreach (string scriptFilePath in scripts)
			{
				AddScript(scriptFilePath);
			}
			RefreshList();
		}

		private void RunScript(PSScipt script)
		{
			RunScript(script.Name, script.Path, script.Parameters.ToDictionary());
		}

		private void RunScript(string scriptName, string scriptFilePath, IDictionary<string, object> parameters = null)
		{
			var result = ScriptRunner.RunScriptFile(scriptFilePath, parameters);
			LogString(scriptName, result);
		}

		private void LogString(string scriptName, string output)
		{
			txtLog.AppendText($"{DateTime.Now.ToString("dd.MM.yyyy hh:mm:ss")}|{scriptName}> {(output != "" ? output : Environment.NewLine)}");
		}

		private void AddScript(string scriptFilePath)
		{
			using (var createScriptDialog = new CreateScriptDialog())
			{
				createScriptDialog.CreateScript(scriptFilePath);

				if (createScriptDialog.ShowDialog() == DialogResult.OK)
				{
					if (!Scripts.Any(s => s.Path == createScriptDialog.Script.Path))
					{
						Scripts.Add(createScriptDialog.Script);
					}
					else
					{
						MessageBox.Show("Script already exists!");
					}
				}
			}
		}

		private void EditScript(PSScipt script)
		{
			using (var createScriptDialog = new CreateScriptDialog())
			{
				createScriptDialog.Script = script;
				createScriptDialog.EditMode = true;

				var result = createScriptDialog.ShowDialog();
				if (result == DialogResult.OK)
				{

				}
				else if (result == DialogResult.Abort)
				{
					Scripts.Remove(script);
				}
			}
			RefreshList();
		}

		private void RefreshList()
		{
			listScriptIcons.Items.Clear();
			foreach (var script in Scripts)
			{
				var listViewItem = new ListViewItem();
				listViewItem.Text = script.Name;
				listViewItem.Tag = script;
				listViewItem.ImageKey = "default";


				listScriptIcons.Items.Add(listViewItem);
			}
		}


		private void listScriptIcons_DrawItem(object sender, DrawListViewItemEventArgs e)
		{

		}

		private void listScriptIcons_DoubleClick(object sender, EventArgs e)
		{
			if (listScriptIcons.SelectedItems.Count > 0)
			{
				var selectedItem = listScriptIcons.SelectedItems[0].Tag as PSScipt;
				RunScript(selectedItem);
			}
		}

		private void txtLog_TextChanged(object sender, EventArgs e)
		{
			// Autoscroll
			txtLog.SelectionStart = txtLog.Text.Length;
			txtLog.ScrollToCaret();
		}

		private void listScriptIcons_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				cmsListScripts.Show(listScriptIcons, e.Location);
			}
		}

		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listScriptIcons.SelectedItems.Count > 0)
			{
				var selectedItem = listScriptIcons.SelectedItems[0].Tag as PSScipt;
				EditScript(selectedItem);
			}
		}
	}
}
