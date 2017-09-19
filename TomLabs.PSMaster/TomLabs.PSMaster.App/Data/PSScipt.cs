using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TomLabs.PSMaster.App.Data
{
	public class PSScipt
	{
		public string Name { get; set; }

		public string Path { get; set; }

		public IEnumerable<PSParam> Parameters { get; set; }

		/// <summary>
		/// Gets or sets whether app should prompt user for filling in parameter values
		/// </summary>
		public bool PromptParams { get; set; }

		public PSScipt()
		{

		}

		public PSScipt(string path)
		{
			Path = path;
			Name = System.IO.Path.GetFileNameWithoutExtension(Path);
			if (File.Exists(Path))
			{
				var script = File.ReadAllText(Path);
				Parameters = ParseParameters(script);
			}
		}

		public PSScipt(string path, IList<PSParam> parameters, bool promptParams = false, string name = null)
		{
			Path = path;
			Parameters = parameters;
			PromptParams = promptParams;
			Name = name ?? System.IO.Path.GetFileNameWithoutExtension(Path);
		}

		private IList<PSParam> ParseParameters(string script)
		{
			var parameters = new List<PSParam>();

			string paramsString = Regex.Match(script, @"param\((.*)\)").Value;
			var matchedParams = Regex.Matches(script, @"(\[(.*?),|\[(.*)\))");
			foreach (Match match in matchedParams)
			{
				string groupedParam = (match.Groups[2]?.Value == "" ? match.Groups[3]?.Value : match.Groups[2]?.Value).Replace(",", "");
				string type = Regex.Match(groupedParam, @"(.*)]").Groups[1]?.Value;
				string name = Regex.Match(groupedParam, @"\]\$(.*)=").Groups[1]?.Value;
				var valueRegex = Regex.Match(groupedParam, @"(=\$(.*)|=(.*))");
				string value = valueRegex.Groups[2]?.Value == "" ? valueRegex.Groups[3]?.Value.Replace("\"", "") : valueRegex.Groups[2]?.Value;

				parameters.Add(new PSParam(name, value, type));
			}

			return parameters;
		}
	}
}
