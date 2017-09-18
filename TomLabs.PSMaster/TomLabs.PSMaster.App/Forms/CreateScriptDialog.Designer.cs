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
			this.label1 = new System.Windows.Forms.Label();
			this.txtScriptPath = new System.Windows.Forms.TextBox();
			this.pnlParams = new System.Windows.Forms.Panel();
			this.groupParams = new System.Windows.Forms.GroupBox();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.groupParams.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Path";
			// 
			// txtScriptPath
			// 
			this.txtScriptPath.Location = new System.Drawing.Point(12, 25);
			this.txtScriptPath.Name = "txtScriptPath";
			this.txtScriptPath.Size = new System.Drawing.Size(402, 20);
			this.txtScriptPath.TabIndex = 1;
			// 
			// pnlParams
			// 
			this.pnlParams.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlParams.Location = new System.Drawing.Point(3, 16);
			this.pnlParams.Name = "pnlParams";
			this.pnlParams.Size = new System.Drawing.Size(396, 185);
			this.pnlParams.TabIndex = 2;
			// 
			// groupParams
			// 
			this.groupParams.Controls.Add(this.pnlParams);
			this.groupParams.Location = new System.Drawing.Point(12, 51);
			this.groupParams.Name = "groupParams";
			this.groupParams.Size = new System.Drawing.Size(402, 204);
			this.groupParams.TabIndex = 3;
			this.groupParams.TabStop = false;
			this.groupParams.Text = "Parameters";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(285, 261);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(126, 50);
			this.btnSave.TabIndex = 4;
			this.btnSave.Text = "Add";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(153, 261);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(126, 50);
			this.btnDelete.TabIndex = 5;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Visible = false;
			// 
			// CreateScriptDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(426, 317);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.groupParams);
			this.Controls.Add(this.txtScriptPath);
			this.Controls.Add(this.label1);
			this.Name = "CreateScriptDialog";
			this.Text = "CreateScriptDialog";
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
	}
}