using System;

namespace TomLabs.PSMaster.App.Data
{
	public class PSParam
	{
		public string Name { get; set; }
		public Type Type { get; set; }
		public object Value { get; set; }

		public PSParam()
		{

		}

		public PSParam(string name, object value, string typeName)
		{
			Name = name;
			Value = value;
			Type = ParseType(typeName);
		}

		private Type ParseType(string typeName)
		{
			return Type.GetType($"System.{FixTypeName(typeName)}");
		}

		private string FixTypeName(string typeName)
		{
			switch (typeName)
			{
				case "Int": return "Int32";
				default: return typeName;
			}
		}
	}
}
