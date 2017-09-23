namespace TomLabs.PSMaster.App.Forms
{
	partial class CreateScriptDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateScriptDialog));
			this.label1 = new System.Windows.Forms.Label();
			this.txtScriptPath = new System.Windows.Forms.TextBox();
			this.pnlParams = new System.Windows.Forms.Panel();
			this.groupParams = new System.Windows.Forms.GroupBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.chckPrompt = new System.Windows.Forms.CheckBox();
			this.btnRun = new System.Windows.Forms.Button();
			this.btnOpenScript = new System.Windows.Forms.Button();
			this.btnReloadParams = new System.Windows.Forms.Button();
			this.groupParams.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(31, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Path";
			// 
			// txtScriptPath
			// 
			this.txtScriptPath.Location = new System.Drawing.Point(12, 25);
			this.txtScriptPath.Name = "txtScriptPath";
			this.txtScriptPath.ReadOnly = true;
			this.txtScriptPath.Size = new System.Drawing.Size(268, 20);
			this.txtScriptPath.TabIndex = 1;
			this.txtScriptPath.DoubleClick += new System.EventHandler(this.txtScriptPath_DoubleClick);
			this.txtScriptPath.MouseHover += new System.EventHandler(this.txtScriptPath_MouseHover);
			// 
			// pnlParams
			// 
			this.pnlParams.AutoScroll = true;
			this.pnlParams.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlParams.Location = new System.Drawing.Point(3, 16);
			this.pnlParams.Name = "pnlParams";
			this.pnlParams.Size = new System.Drawing.Size(317, 112);
			this.pnlParams.TabIndex = 2;
			// 
			// groupParams
			// 
			this.groupParams.Controls.Add(this.pnlParams);
			this.groupParams.Location = new System.Drawing.Point(12, 51);
			this.groupParams.Name = "groupParams";
			this.groupParams.Size = new System.Drawing.Size(323, 131);
			this.groupParams.TabIndex = 3;
			this.groupParams.TabStop = false;
			this.groupParams.Text = "Parameters";
			// 
			// btnSave
			// 
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.btnSave.Location = new System.Drawing.Point(210, 211);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(126, 50);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(12, 211);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(126, 50);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Visible = false;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// toolTip
			// 
			this.toolTip.BackColor = System.Drawing.SystemColors.HighlightText;
			// 
			// chckPrompt
			// 
			this.chckPrompt.AutoSize = true;
			this.chckPrompt.Location = new System.Drawing.Point(15, 188);
			this.chckPrompt.Name = "chckPrompt";
			this.chckPrompt.Size = new System.Drawing.Size(134, 17);
			this.chckPrompt.TabIndex = 6;
			this.chckPrompt.Text = "Prompt before run?";
			this.chckPrompt.UseVisualStyleBackColor = true;
			// 
			// btnRun
			// 
			this.btnRun.Location = new System.Drawing.Point(106, 211);
			this.btnRun.Name = "btnRun";
			this.btnRun.Size = new System.Drawing.Size(126, 50);
			this.btnRun.TabIndex = 7;
			this.btnRun.Text = "Run";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Visible = false;
			this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
			// 
			// btnOpenScript
			// 
			this.btnOpenScript.BackgroundImage = global::TomLabs.PSMaster.App.Properties.Resources.open_file;
			this.btnOpenScript.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnOpenScript.Location = new System.Drawing.Point(286, 23);
			this.btnOpenScript.Name = "btnOpenScript";
			this.btnOpenScript.Size = new System.Drawing.Size(24, 24);
			this.btnOpenScript.TabIndex = 8;
			this.toolTip.SetToolTip(this.btnOpenScript, "Open script");
			this.btnOpenScript.UseVisualStyleBackColor = true;
			this.btnOpenScript.Click += new System.EventHandler(this.btnOpenScript_Click);
			// 
			// btnReloadParams
			// 
			this.btnReloadParams.BackgroundImage = global::TomLabs.PSMaster.App.Properties.Resources.refresh;
			this.btnReloadParams.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnReloadParams.Location = new System.Drawing.Point(312, 23);
			this.btnReloadParams.Name = "btnReloadParams";
			this.btnReloadParams.Size = new System.Drawing.Size(24, 24);
			this.btnReloadParams.TabIndex = 9;
			this.toolTip.SetToolTip(this.btnReloadParams, "Refresh params");
			this.btnReloadParams.UseVisualStyleBackColor = true;
			this.btnReloadParams.Click += new System.EventHandler(this.btnReloadParams_Click);
			// 
			// CreateScriptDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
			this.ClientSize = new System.Drawing.Size(347, 274);
			this.Controls.Add(this.btnReloadParams);
			this.Controls.Add(this.btnOpenScript);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.chckPrompt);
			this.Controls.Add(this.groupParams);
			this.Controls.Add(this.txtScriptPath);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CreateScriptDialog";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Script";
			this.Load += new System.EventHandler(this.CreateScriptDialog_Load);
			this.groupParams.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtScriptPath;
		private System.Windows.Forms.Panel pnlParams;
		private System.Windows.Forms.GroupBox groupParams;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.CheckBox chckPrompt;
		private System.Windows.Forms.Button btnRun;
		private System.Windows.Forms.Button btnOpenScript;
		private System.Windows.Forms.Button btnReloadParams;
	}
}