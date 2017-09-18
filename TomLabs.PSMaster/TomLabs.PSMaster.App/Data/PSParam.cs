using System;

namespace TomLabs.PSMaster.App.Data
{
	public class PSParam
	{
		public string ParamName { get; set; }
		public Type Type { get; set; }
		public object DefaultValue { get; set; }
	}
}
