using System;
using System.Xml.Serialization;

namespace TomLabs.PSMaster.App.Data
{
	public class PSParam
	{
		public string Name { get; set; }

		[XmlIgnore]
		public Type Type { get; protected set; }

		private string _typeName;
		public string TypeName
		{
			get { return _typeName; }
			set
			{
				_typeName = value;
				Type = ParseType(_typeName);
			}
		}

		public object Value { get; set; }

		public PSParam()
		{

		}

		public PSParam(string name, object value, string typeName)
		{
			Name = name;
			Value = value;
			TypeName = typeName;
			Type = ParseType(TypeName);
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
