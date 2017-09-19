using System.Collections.Generic;
using System.Linq;
using TomLabs.PSMaster.App.Data;

namespace TomLabs.PSMaster.App.Extensions
{
	public static class PSExtensions
	{
		public static IDictionary<string, object> ToDictionary(this IEnumerable<PSParam> paramList)
		{
			return paramList?.ToDictionary(p => p.Name, v => v.Value);
		}
	}
}
