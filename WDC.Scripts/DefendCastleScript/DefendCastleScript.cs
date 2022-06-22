using DefendCastleScript.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using WDC.Core;
using WDC.Script;
using WDC.UI;

namespace DefendCastleScript
{
    public class DefendCastleScript : WDCScript
    {
        private int winHeight;
        private int winWidth;
        private Engine engine;

        public string Icon
        {
            get { return "./Icons/DefendCastleScript/icon.ico"; }
        }

        public void BeforeRunScript()
        {
        }

        public void Init(Engine engine)
        {
            this.engine = engine;

            winHeight = Engine.WinHeight;
            winWidth = Engine.WinWidth; 
        }

        public void Render(Graphics g, IRenderer renderer)
        {
        }
    }
}
