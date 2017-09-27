using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TomLabs.PowerClam;
using TomLabs.PowerClam.Data;
using TomLabs.PowerClam.Extensions;
using TomLabs.PSMaster.App.Properties;
using TomLabs.Shadowgem.Extensions;
using TomLabs.Shadowgem.Extensions.String;

namespace TomLabs.PSMaster.App.Forms
{
	public partial class MainForm : Form
	{
		private List<PSScipt> _scripts = new List<PSScipt>();
		private List<PSScipt> Scripts
		{
			get { return _scripts; }
			set
			{
				_scripts = value;
				RefreshList();
			}
		}

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
			var output = ScriptRunner.RunScriptFile(scriptFilePath, parameters);
			LogScriptResult(scriptName, output, Path.GetDirectoryName(scriptFilePath));
		}

		private void LogScriptResult(string scriptName, string output, string workingDirectory)
		{
			txtLog.AppendText($"PS {workingDirectory}> .\\{scriptName}.ps1 {(output != "" ? output : Environment.NewLine)}");
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
					DeleteScript(script);
				}
			}
		}

		private void DeleteScript(PSScipt script)
		{
			Scripts.Remove(script);
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
				Settings.Default.SortDirection = (int)listScriptIcons.Sorting;
			}

			Settings.Default.MainFormSize = new Size(Width, Height);
			Settings.Default.Save();
		}

		private void LoadScripts()
		{
			if (Settings.Default.MainFormSize.Width > 0 && Settings.Default.MainFormSize.Height > 0)
			{
				Width = Settings.Default.MainFormSize.Width;
				Height = Settings.Default.MainFormSize.Height;
			}

			if (Settings.Default.ScriptsMetadata.IsFilled())
			{
				Scripts = Settings.Default.ScriptsMetadata.XmlDeserialize<List<PSScipt>>();
				listScriptIcons.Sorting = (SortOrder)Settings.Default.SortDirection;
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

		private void runToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listScriptIcons.SelectedItems.Count > 0)
			{
				foreach (PSScipt script in listScriptIcons.SelectedItems.Cast<ListViewItem>().Select(c => c.Tag))
				{
					RunScript(script);
				}
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

		private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (listScriptIcons.SelectedItems.Count > 0)
			{
				var selectedItem = listScriptIcons.SelectedItems[0].Tag as PSScipt;
				DeleteScript(selectedItem);
			}
		}

		private void ascToolStripMenuItem_Click(object sender, EventArgs e)
		{
			listScriptIcons.Sorting = SortOrder.Ascending;
		}

		private void descToolStripMenuItem_Click(object sender, EventArgs e)
		{
			listScriptIcons.Sorting = SortOrder.Descending;
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
