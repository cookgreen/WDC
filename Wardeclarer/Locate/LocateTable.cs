using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Locate
{
	public class LocateTable
	{
		private List<LocateTableEntry> entries;
		public LocateTable()
		{
			entries = new List<LocateTableEntry>();
		}

		public void AddEntry(string id, string langID, string value)
		{
			entries.Add(new LocateTableEntry()
			{
				ID      =   id,
				LangID  =   langID,
				Value   =   value
			});
		}

		public string GetEntry(string id, string langID)
		{
			var result = entries.Where(o => o.ID == id && o.LangID == langID);
			if (result.Count() > 0)
			{
				var entry = result.ElementAt(0);
				return entry.Value;
			}
			else
			{
				return null;
			}
		}
	}
}
