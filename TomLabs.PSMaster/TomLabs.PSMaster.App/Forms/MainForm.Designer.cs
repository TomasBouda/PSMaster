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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.listScriptIcons = new System.Windows.Forms.ListView();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mitemNewScript = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.txtLog = new System.Windows.Forms.RichTextBox();
			this.cmsListScripts = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ascToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.descToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.cmsListScripts.SuspendLayout();
			this.SuspendLayout();
			// 
			// listScriptIcons
			// 
			this.listScriptIcons.AllowDrop = true;
			this.listScriptIcons.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listScriptIcons.Location = new System.Drawing.Point(0, 0);
			this.listScriptIcons.Name = "listScriptIcons";
			this.listScriptIcons.Size = new System.Drawing.Size(368, 300);
			this.listScriptIcons.TabIndex = 0;
			this.listScriptIcons.UseCompatibleStateImageBehavior = false;
			this.listScriptIcons.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listScriptIcons_DrawItem);
			this.listScriptIcons.DragDrop += new System.Windows.Forms.DragEventHandler(this.listScriptIcons_DragDrop);
			this.listScriptIcons.DragEnter += new System.Windows.Forms.DragEventHandler(this.listScriptIcons_DragEnter);
			this.listScriptIcons.DoubleClick += new System.EventHandler(this.listScriptIcons_DoubleClick);
			this.listScriptIcons.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listScriptIcons_MouseClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(368, 24);
			this.menuStrip1.TabIndex = 1;
			this.menuStrip1.Text = "menuStrip1";
			this.menuStrip1.Visible = false;
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
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.listScriptIcons);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.txtLog);
			this.splitContainer1.Size = new System.Drawing.Size(368, 364);
			this.splitContainer1.SplitterDistance = 300;
			this.splitContainer1.TabIndex = 2;
			// 
			// txtLog
			// 
			this.txtLog.BackColor = System.Drawing.Color.Navy;
			this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.txtLog.ForeColor = System.Drawing.SystemColors.InactiveBorder;
			this.txtLog.Location = new System.Drawing.Point(0, 0);
			this.txtLog.Name = "txtLog";
			this.txtLog.Size = new System.Drawing.Size(368, 60);
			this.txtLog.TabIndex = 0;
			this.txtLog.Text = "";
			this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
			// 
			// cmsListScripts
			// 
			this.cmsListScripts.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.sortToolStripMenuItem});
			this.cmsListScripts.Name = "cmsListScripts";
			this.cmsListScripts.Size = new System.Drawing.Size(153, 114);
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.editToolStripMenuItem.Text = "Edit";
			this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
			// 
			// sortToolStripMenuItem
			// 
			this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ascToolStripMenuItem,
            this.descToolStripMenuItem});
			this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
			this.sortToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.sortToolStripMenuItem.Text = "Sort";
			// 
			// ascToolStripMenuItem
			// 
			this.ascToolStripMenuItem.Name = "ascToolStripMenuItem";
			this.ascToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.ascToolStripMenuItem.Text = "asc";
			this.ascToolStripMenuItem.Click += new System.EventHandler(this.ascToolStripMenuItem_Click);
			// 
			// descToolStripMenuItem
			// 
			this.descToolStripMenuItem.Name = "descToolStripMenuItem";
			this.descToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.descToolStripMenuItem.Text = "desc";
			this.descToolStripMenuItem.Click += new System.EventHandler(this.descToolStripMenuItem_Click);
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.runToolStripMenuItem.Text = "Run";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(368, 364);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "PSMaster";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.cmsListScripts.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listScriptIcons;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mitemNewScript;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.RichTextBox txtLog;
		private System.Windows.Forms.ContextMenuStrip cmsListScripts;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem sortToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ascToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem descToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
	}
}

