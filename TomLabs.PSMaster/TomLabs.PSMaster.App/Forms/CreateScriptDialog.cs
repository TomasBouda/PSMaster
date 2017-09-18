using System.Windows.Forms;
using TomLabs.PSMaster.App.Data;

namespace TomLabs.PSMaster.App.Forms
{
	public partial class CreateScriptDialog : Form
	{
		public string ScriptPath
		{
			get { return txtScriptPath.Text; }
			set { txtScriptPath.Text = value; }
		}

		public PSScipt Script { get; set; }

		public CreateScriptDialog()
		{
			InitializeComponent();
		}

		private void CreateScript()
		{
			Script = new PSScipt(ScriptPath, null, false);//TODO
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			CreateScript();
			DialogResult = DialogResult.OK;
			Close();
		}
	}
}
