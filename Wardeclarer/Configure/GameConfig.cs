using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardeclarer.Script;

namespace Wardeclarer.Configure
{
	public class GameConfig
	{
		public WDCScript CurrentSelectedScript { get; set; }
		public string CurrentSelectedLocate { get; set; }
		public string Resolution { get; set; }
	}
}
