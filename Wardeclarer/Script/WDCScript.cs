using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Script
{
	public interface WDCScript
	{
		void BeforeRunScript();

		void Init(int winWidth, int winHeight);

		void MouseClicked(int x, int y);

		void Update(Graphics g);

		void SetRenderPanel(frmRenderPanel frmRenderPanel);
	}
}
