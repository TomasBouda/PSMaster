namespace TomLabs.PSMaster.App.Forms
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.listScriptIcons = new System.Windows.Forms.ListView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNewScript = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listScriptIcons
			// 
			this.listScriptIcons.AllowDrop = true;
			this.listScriptIcons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listScriptIcons.Location = new System.Drawing.Point(0, 24);
			this.listScriptIcons.Name = "listScriptIcons";
			this.listScriptIcons.Size = new System.Drawing.Size(368, 340);
			this.listScriptIcons.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listScriptIcons.TabIndex = 0;
			this.listScriptIcons.UseCompatibleStateImageBehavior = false;
			this.listScriptIcons.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listScriptIcons_DrawItem);
			this.listScriptIcons.DragDrop += new System.Windows.Forms.DragEventHandler(this.listScriptIcons_DragDrop);
			this.listScriptIcons.DragEnter += new System.Windows.Forms.DragEventHandler(this.listScriptIcons_DragEnter);
			this.listScriptIcons.DoubleClick += new System.EventHandler(this.listScriptIcons_DoubleClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(368, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// addToolStripMenuItem
			// 
			this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mitemNewScript});
			this.addToolStripMenuItem.Name = "addToolStripMenuItem";
			this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.addToolStripMenuItem.Text = "Add";
			// 
			// mitemNewScript
			// 
			this.mitemNewScript.Name = "mitemNewScript";
			this.mitemNewScript.Size = new System.Drawing.Size(130, 22);
			this.mitemNewScript.Text = "New script";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(368, 364);
			this.Controls.Add(this.listScriptIcons);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.Text = "PSMaster";
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listScriptIcons;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mitemNewScript;
	}
}

