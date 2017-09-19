using System;
using System.Linq;
using System.Windows.Forms;
using TomLabs.PSMaster.App.Data;

namespace TomLabs.PSMaster.App.Forms
{
	public partial class CreateScriptDialog : Form
	{
		public bool EditMode { get; set; }

		public string ScriptPath
		{
			get { return txtScriptPath.Text; }
			set
			{
				txtScriptPath.Text = value;
			}
		}

		public PSScipt Script { get; set; }

		public CreateScriptDialog()
		{
			InitializeComponent();
		}

		public void CreateScript(string scriptPath)
		{
			ScriptPath = scriptPath;
			Script = new PSScipt(ScriptPath);
			ShowParams();
		}

		private void CreateScriptDialog_Load(object senderm, System.EventArgs e)
		{
			if (EditMode)
			{
				ShowParams();
				btnDelete.Visible = true;
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			DeserializeParams();
			DialogResult = DialogResult.OK;
			Close();
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
				lblParamName.Text = param.Name;
				lblParamName.Top = top;
				lblParamName.Left = left;
				pnlParams.Controls.Add(lblParamName);

				if (param.Type.Name != "Boolean")
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

		private void btnDelete_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Abort;
			Close();
		}
	}
}
