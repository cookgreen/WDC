using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Locate
{
	public class LocateTableManager
	{
		private string currentLocate;
		private LocateTable currentTable;
		private static LocateTableManager instance;
		public static LocateTableManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new LocateTableManager();
				}
				return instance;
			}
		}

		public LocateTable CurrentTable
		{
			get
			{
				return currentTable;
			}
		}

		public string CurrentLocate
		{
			get
			{
				return currentLocate;
			}
		}

		public LocateTableManager()
		{
			currentTable = new LocateTable();
		}

		public string ConvertDisplayStrToID(string displayStr)
		{
			string strID = null;
			switch (displayStr)
			{
				case "简体中文":
					strID = "cns";
					break;
				case "English":
					strID = "en";
					break;
				default:
					strID = "unknown";
					break;
			}
			return strID;
		}

		public void Init(string currentLocate)
		{
			this.currentLocate = currentLocate;
		}

        public object ConvertIDToDisplayStr(string id)
        {
            string displayStr = null;
            switch (id)
            {
                case "cns":
                    displayStr = "简体中文";
                    break;
                case "en":
                    displayStr = "English";
                    break;
                default:
                    displayStr = "unknown";
                    break;
            }
            return displayStr;
        }
    }
}
