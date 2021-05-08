﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.Script
{
	public interface WDCScript : IRenderable
	{
		void BeforeRunScript();

		void Init(Engine engine);

		void SetRenderPanel(frmRenderPanel frmRenderPanel);
	}
}
