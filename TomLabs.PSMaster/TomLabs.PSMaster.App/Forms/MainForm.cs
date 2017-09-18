using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TomLabs.PowerClam;
using TomLabs.PSMaster.App.Data;

namespace TomLabs.PSMaster.App.Forms
{
	public partial class MainForm : Form
	{
		private List<PSScipt> Scripts { get; set; } = new List<PSScipt>();

		public MainForm()
		{
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

		private void AddScript(string scriptFilePath)
		{
			using (var createScriptDialog = new CreateScriptDialog())
			{
				createScriptDialog.ScriptPath = scriptFilePath;

				if (createScriptDialog.ShowDialog() == DialogResult.OK)
				{
					Scripts.Add(createScriptDialog.Script);
				}
			}
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
				var result = ScriptRunner.RunScriptFile(selectedItem.Path);//TODO log
			}
		}
	}
}
