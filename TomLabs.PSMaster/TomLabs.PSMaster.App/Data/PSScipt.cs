using System.Collections.Generic;

namespace TomLabs.PSMaster.App.Data
{
	public class PSScipt
	{
		public string Name { get; set; }

		public string Path { get; set; }

		public IList<PSParam> Parameters { get; set; }

		/// <summary>
		/// Gets or sets whether app should prompt user for filling in parameter values
		/// </summary>
		public bool PromptParams { get; set; }

		public PSScipt()
		{

		}

		public PSScipt(string path, IList<PSParam> parameters, bool promptParams = false, string name = null)
		{
			Path = path;
			Parameters = parameters;
			PromptParams = promptParams;
			Name = name ?? System.IO.Path.GetFileName(Path);
		}
	}
}
