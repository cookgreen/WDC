using EWCGame.Screens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;
using WDC.Script;

namespace EWCGame
{
    /// <summary>
    /// East West Conflict: Dunbas War Main Script
    /// </summary>
    public class EWCGameScript : IWDCScript
    {
        public string Name { get { return "East West Conflict: Dunbas War"; } }

        public string Icon { get { return ""; } }

        public void BeforeRunScript()
        {
        }

        public void Init(Engine engine)
        {
        }

        public void MouseClicked(int x, int y)
        {
        }

        public void MouseMoved(int x, int y)
        {
        }

        public void Render(Graphics g, IRenderer renderer)
        {
            GameScreenManager.Instance.ChangeScreen("MainMenu", g, renderer);
        }

        public void Update()
        {

        }
    }
}
