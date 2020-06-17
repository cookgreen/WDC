using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardeclarer.Core;

namespace Wardeclarer.Script
{
	public interface WDCScript
	{
		void BeforeRunScript();

		void Init(int winWidth, int winHeight, Engine engine);

		void Update(Graphics g);

		void SetRenderPanel(frmRenderPanel frmRenderPanel);
	}
}
