using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TomLabs.PowerClam.Data;

namespace TomLabs.PSMaster.App.Forms
{
	public enum EDialogMode
	{
		Create,
		Edit,
		Run
	}

	public partial class CreateScriptDialog : Form
	{
		public EDialogMode DialogMode { get; private set; }

		public string ScriptPath
		{
			get { return txtScriptPath.Text; }
			private set
			{
				txtScriptPath.Text = value;
				txtScriptPath.SelectionStart = txtScriptPath.Text.Length - 1;
				txtScriptPath.SelectionLength = 0;
			}
		}

		public PSScipt Script { get; private set; }

		public CreateScriptDialog()
		{
			InitializeComponent();
		}

		#region Private Methods

		public DialogResult CreateScript(PSScipt script)
		{
			return Init(EDialogMode.Create, script);
		}

		public DialogResult EditScript(PSScipt script)
		{
			return Init(EDialogMode.Edit, script);
		}

		public DialogResult RunScript(PSScipt script)
		{
			return Init(EDialogMode.Run, script);
		}

		private DialogResult Init(EDialogMode mode, PSScipt script)
		{
			DialogMode = mode;
			Script = script;
			ScriptPath = Script.Path;
			chckPrompt.Checked = Script.PromptParams;
			ShowParams();
			return ShowDialog();
		}

		private void ShowParams()
		{
			pnlParams.Controls.Clear();
			var parameters = Script.Parameters?.ToList();
			for (int i = 0; i < parameters.Count; i++)
			{
				var param = parameters[i];
				int top = i * 25;
				int left = 0;
				int editLeft = 130;

				var lblParamType = new Label();
				lblParamType.AutoSize = true;
				lblParamType.Text = $"[{param.TypeName}]";
				lblParamType.Top = top + 2;
				lblParamType.Left = left;
				lblParamType.ForeColor = Color.Blue;
				pnlParams.Controls.Add(lblParamType);

				var lblParamName = new Label();
				lblParamName.AutoSize = true;
				lblParamName.Font = new System.Drawing.Font(lblParamName.Font.FontFamily, lblParamName.Font.Size, System.Drawing.FontStyle.Bold);
				lblParamName.Text = param.Name;
				lblParamName.Top = top + 2;
				lblParamName.Left = lblParamType.Width;
				pnlParams.Controls.Add(lblParamName);

				if (param.TypeName != "Boolean")
				{
					var txtParamValue = new TextBox();
					txtParamValue.Width = 150;
					txtParamValue.Text = param.Value.ToString().Replace("\"", "");
					txtParamValue.Top = top;
					txtParamValue.Left = editLeft;
					txtParamValue.Tag = param;
					pnlParams.Controls.Add(txtParamValue);
				}
				else
				{
					var chckParamValue = new CheckBox();
					chckParamValue.Top = top - 2;
					chckParamValue.Left = editLeft;
					chckParamValue.Tag = param;
					chckParamValue.Checked = bool.Parse(param.Value.ToString().Replace("$", ""));
					pnlParams.Controls.Add(chckParamValue);
				}
			}
		}

		private void DeserializeParams()
		{
			foreach (var control in pnlParams.Controls)
			{
				if (control is TextBox)
				{
					var txtParamValue = control as TextBox;
					var param = txtParamValue.Tag as PSParam;
					Script.Parameters.Single(p => p == param).Value = param.HandleParamValue(txtParamValue.Text);
				}
				else if (control is CheckBox)
				{
					var chckParamValue = control as CheckBox;
					var param = chckParamValue.Tag as PSParam;
					Script.Parameters.Single(p => p == param).Value = param.HandleParamValue(chckParamValue.Checked);
				}
			}
		}

		private void Save()
		{
			Script.PromptParams = chckPrompt.Checked;
			DeserializeParams();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void OpenScript()
		{
			Process.Start(ScriptPath);
		}

		private void ReloadParams()
		{
			Script.LoadParameters();
			ShowParams();
		}

		#endregion Private Methods

		private void CreateScriptDialog_Load(object senderm, System.EventArgs e)
		{
			if (DialogMode == EDialogMode.Edit)
			{
				btnDelete.Visible = true;

				this.Text = "Edit Script";
			}
			else if (DialogMode == EDialogMode.Run)
			{
				btnRun.Visible = true;
				chckPrompt.Visible = false;
				btnSave.Visible = false;

				this.Text = "Run Script";
			}
			else
			{
				this.Text = "Create Script";
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			Save();
		}
		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Abort;
			Close();
		}

		private void txtScriptPath_MouseHover(object sender, EventArgs e)
		{
			toolTip.Show(ScriptPath, txtScriptPath);
		}

		private void btnRun_Click(object sender, EventArgs e)
		{
			Save();
		}

		private void btnOpenScript_Click(object sender, EventArgs e)
		{
			OpenScript();
		}

		private void btnReloadParams_Click(object sender, EventArgs e)
		{
			ReloadParams();
		}
	}
}
