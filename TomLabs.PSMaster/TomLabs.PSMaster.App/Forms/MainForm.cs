using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TomLabs.PowerClam;
using TomLabs.PSMaster.App.Data;
using TomLabs.PSMaster.App.Extensions;
using TomLabs.PSMaster.App.Properties;
using TomLabs.Shadowgem.Extensions;
using TomLabs.Shadowgem.Extensions.String;

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

			SetupImageList();
		}

		#region Private Methods

		private void RunScript(PSScipt script)
		{
			if (script.PromptParams)
			{
				using (var createScriptDialog = new CreateScriptDialog())
				{
					if (createScriptDialog.RunScript(script) != DialogResult.OK)
					{
						return;
					}
				}
			}

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
			if (!Scripts.Any(s => s.Path == scriptFilePath))
			{
				using (var createScriptDialog = new CreateScriptDialog())
				{
					if (createScriptDialog.CreateScript(new PSScipt(scriptFilePath)) == DialogResult.OK)
					{
						Scripts.Add(createScriptDialog.Script);
					}
				}
			}
			else
			{
				MessageBox.Show("Script already exists!");
			}
		}

		private void EditScript(PSScipt script)
		{
			using (var createScriptDialog = new CreateScriptDialog())
			{
				var result = createScriptDialog.EditScript(script);
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

		private void SetupImageList()
		{
			ImageList iList = new ImageList();
			iList.ImageSize = new Size(64, 64);
			iList.ColorDepth = ColorDepth.Depth32Bit;
			iList.Images.Add("default", Resources.script_icon);
			listScriptIcons.LargeImageList = iList;
		}

		private void SaveScripts()
		{
			if (Scripts?.Count > 0)
			{
				Settings.Default.ScriptsMetadata = Scripts.XmlSerialize();
				Settings.Default.Save();
			}
		}

		private void LoadScripts()
		{
			if (Settings.Default.ScriptsMetadata.IsFilled())
			{
				Scripts = Settings.Default.ScriptsMetadata.XmlDeserialize<List<PSScipt>>();
				RefreshList();
			}
		}

		#endregion Private Methods



		#region Event Handlers

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

		private void listScriptIcons_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				cmsListScripts.Show(listScriptIcons, e.Location);
			}
		}

		private void txtLog_TextChanged(object sender, EventArgs e)
		{
			// Autoscroll
			txtLog.SelectionStart = txtLog.Text.Length;
			txtLog.ScrollToCaret();
		}
		private void editToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listScriptIcons.SelectedItems.Count > 0)
			{
				var selectedItem = listScriptIcons.SelectedItems[0].Tag as PSScipt;
				EditScript(selectedItem);
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			LoadScripts();
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveScripts();
		}

		#endregion Event Handlers

	}
}
