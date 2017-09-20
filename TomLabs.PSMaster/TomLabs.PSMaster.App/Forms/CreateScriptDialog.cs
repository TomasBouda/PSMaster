using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using TomLabs.PSMaster.App.Data;

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
			var parameters = Script.Parameters.ToList();
			for (int i = 0; i < parameters.Count; i++)
			{
				var param = parameters[i];
				int top = i * 25;
				int left = 0;
				var lblParamName = new Label();
				lblParamName.Width = 100;
				lblParamName.Text = $"[{param.TypeName}]{param.Name}";
				lblParamName.Top = top + 5;
				lblParamName.Left = left;
				pnlParams.Controls.Add(lblParamName);

				if (param.TypeName != "Boolean")
				{
					var txtParamValue = new TextBox();
					txtParamValue.Width = 100;
					txtParamValue.Text = param.Value.ToString().Replace("\"", "");
					txtParamValue.Top = top;
					txtParamValue.Left = left + lblParamName.Width;
					txtParamValue.Tag = param;
					pnlParams.Controls.Add(txtParamValue);
				}
				else
				{
					var chckParamValue = new CheckBox();
					chckParamValue.Top = top;
					chckParamValue.Left = left + lblParamName.Width;
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
					Script.Parameters.Single(p => p == param).Value = HandleParamValue(txtParamValue.Text, param.Type);
				}
				else if (control is CheckBox)
				{
					var chckParamValue = control as CheckBox;
					var param = chckParamValue.Tag as PSParam;
					Script.Parameters.Single(p => p == param).Value = HandleParamValue(chckParamValue.Checked, param.Type);
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

		#endregion Private Methods

		private object HandleParamValue(object textValue, Type type)
		{
			if (type.Name == "String")
			{
				return $"\"{textValue}\"";
			}
			else if (type.Name == "Boolean")
			{
				return $"${textValue}";
			}
			else
			{
				return textValue;
			}
		}

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
	}
}
