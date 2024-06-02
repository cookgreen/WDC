using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace EWCGame.Screens
{
    public class GameScreenManager
    {
        private IGameScreen currentScreen;
        private Dictionary<string, IGameScreen> screens;

        private static GameScreenManager instance;
        public static GameScreenManager Instance
        {
            get
            {
                if(instance == null)
                    instance = new GameScreenManager();
                return instance;
            }
        }

        public GameScreenManager()
        {
            screens = new Dictionary<string, IGameScreen>();

            screens["MainMenu"] = new GameMainMenuScreen();
            screens["InnerGame"] = new GameInnerScreen();
            screens["CampaignSelect"] = new GameCampaignsSelectScreen();
        }

        public void ChangeScreen(string screenName, Graphics g, IRenderer renderer)
        {
            currentScreen = screens[screenName];
            currentScreen.Render(g, renderer);
        }
    }
}
