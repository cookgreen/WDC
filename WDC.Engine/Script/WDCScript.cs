using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;
using WDC.Forms;

namespace WDC.Script
{
	public interface WDCScript : IRenderable
	{
		string Icon { get; }

		void BeforeRunScript();

		void Init(Engine engine);
	}
}
