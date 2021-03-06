﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Game;
using WDC.UI;
using WDC.Interface;
using WardeclarerScript.Properties;
using System.Windows.Forms;
using WDC.Core;

namespace WDC.Script
{
    public class WardeclarerScript : WDCScript, INotifyMessageWhenShutdown
    {
        private frmRenderPanel renderPanel;
        private PointF missileShootStartPosition = new PointF(-1, -1);
        private PointF missileShootEndPosition = new PointF(-1, -1);
        private PointF missileShootEndPositionUSA = new PointF(-1, -1);
        private PointF missileShootEndPositionGermany = new PointF(-1, -1);
        private int missileShootTolerance;

        private PointF missileShootStartPositionOriginal = new PointF(743, 134);
        private PointF missileShootEndPositionUSAOriginal = new PointF(153, 169);
        private PointF missileShootEndPositionGermanyOriginal = new PointF(417, 161);
        private int missileShootToleranceOriginal = 15;

        private PointF missileShootStartPosition_1920x1080 = new PointF(1488, 329);
        private PointF missileShootEndPositionUSA_1920x1080 = new PointF(322, 389);
        private PointF missileShootEndPositionGermany_1920x1080 = new PointF(950, 366);
        private int missileShootTolerance_1920x1080 = 150;

        private PointF missileShootStartPosition_1366x768 = new PointF(1058, 211);
        private PointF missileShootEndPositionUSA_1366x768 = new PointF(244, 275);
        private PointF missileShootEndPositionGermany_1366x768 = new PointF(676, 246);

        private PointF missileShootStartPosition_1024x768 = new PointF(793, 211);
        private PointF missileShootEndPositionUSA_1024x768 = new PointF(172, 272);
        private PointF missileShootEndPositionGermany_1024x768 = new PointF(503, 247);
        private int winWidth;
        private int winHeight;
        private GDIStaticText text1;
        private GDIStaticText text2;
        private GDIStaticText text3;
        private GDISelectableOption option1;
        private GDISelectableOption option2;
        private List<GDISelectableOption> options;
        private Sprite missile;
        private Sprite cloud;
        private bool clicked;
        private bool reached;
        private Engine engine;
        public event Action<string, string> ShutdownShowMessage;
        public WardeclarerScript()
        {
        }

        public void Init(Engine engine)
        {
            winHeight = Engine.WinHeight;
            winWidth = Engine.WinWidth;
            clicked = false;
            reached = false;
            text1 = new GDIStaticText("Hello Comrade", "Baskerville Old Face", 50, Brushes.White, new PointF(0, winHeight), true);
            text2 = new GDIStaticText("Which country do you wanna destroy today?", "Baskerville Old Face", 40, Brushes.White, new PointF(0, winHeight), true);
            text3 = new GDIStaticText("OK", "Baskerville Old Face", 60, Brushes.White, new PointF(0, winHeight), true);
            options = new List<GDISelectableOption>();
            option1 = new GDISelectableOption("a:) USA[imperialists]", "Arial", 40, Brushes.White, new PointF(0, winHeight), ref options, true);
            options.Add(option1);
            option2 = new GDISelectableOption("b:) Germany[Nazis]", "Arial", 40, Brushes.White, new PointF(0, winHeight), ref options, true);
            options.Add(option2);
            for (int i = 0; i < options.Count; i++)
            {
                options[i].Position = new PointF(0, winHeight - ((options.Count - i) * options[i].Height));
            }

            if (winWidth == 1920 && winHeight == 1080)
            {
                missileShootStartPosition = missileShootStartPosition_1920x1080;
                missileShootEndPositionUSA = missileShootEndPositionUSA_1920x1080;
                missileShootEndPositionGermany = missileShootEndPositionGermany_1920x1080;
                missileShootTolerance = missileShootToleranceOriginal;
            }
            else if (winWidth == 1366 && winHeight == 768)
            {
                missileShootStartPosition = missileShootStartPosition_1366x768;
                missileShootEndPositionUSA = missileShootEndPositionUSA_1366x768;
                missileShootEndPositionGermany = missileShootEndPositionGermany_1366x768;
                missileShootTolerance = missileShootToleranceOriginal;
            }
            else if (winWidth == 1024 && winHeight == 768)
            {
                missileShootStartPosition = missileShootStartPosition_1024x768;
                missileShootEndPositionUSA = missileShootEndPositionUSA_1024x768;
                missileShootEndPositionGermany = missileShootEndPositionGermany_1024x768;
                missileShootTolerance = missileShootTolerance_1920x1080;
            }
            else
            {
                missileShootStartPosition = missileShootStartPositionOriginal;
                missileShootEndPositionUSA = missileShootEndPositionUSAOriginal;
                missileShootEndPositionGermany = missileShootEndPositionGermanyOriginal;
                missileShootTolerance = missileShootToleranceOriginal;
            }

            missile = new Sprite(Resources.missile, missileShootStartPosition, missileShootTolerance, 0.8f);
            missile.SetSteering(new SpriteAxisMovement(0, 1, missileShootStartPosition, 10));
            missile.DestReached += Sprite_DestReached;

			option1.MouseClicked += Option1_MouseClicked;
			option2.MouseClicked += Option2_MouseClicked;
            this.engine = engine;
        }

		private void Option1_MouseClicked()
        {
            counter2 = counter;
            clicked = true;
            missileShootEndPosition = missileShootEndPositionUSA;
            missile.MoveTo(missileShootEndPosition);
            cloud = new Sprite(Resources.nuclear_boom, missileShootEndPosition, 0, 0.6f, AlignMethod.BOTTOM);
            engine.GameObjects.Remove(option1);
            engine.GameObjects.Remove(option2);
        }

        private void Option2_MouseClicked()
        {
            counter2 = counter;
            clicked = true;
            missileShootEndPosition = missileShootEndPositionGermany;
            missile.MoveTo(missileShootEndPosition);
            cloud = new Sprite(Resources.nuclear_boom, missileShootEndPosition, 0, 0.6f, AlignMethod.BOTTOM);
            engine.GameObjects.Remove(option1);
            engine.GameObjects.Remove(option2);
        }

        private void Sprite_DestReached()
        {
            reached = true;
            deadline = 30;
        }

        private int counter = 0;
        private int counter2 = 0;
        private int deadline = 100;
        public void Render(Graphics g, IRenderer renderer)
        {
            if (counter >= 0 && counter <= 35)
            {
                //Hello Comrade
                text1.Draw(g);
            }
            else if (counter > 35 && counter <= 70)
            {
                //Which country do you wanna destroy today
                text2.Draw(g);
            }
            else if (!clicked)
            {
                engine.AddIfNotExisted(option1);
                engine.AddIfNotExisted(option2);
            }
            else if (counter > counter2 && counter <= counter2 + 20)
            {
                text3.Draw(g);
            }
            else if (counter > counter2 + 20 && !reached)
            {
                missile.Render(g, renderer);
            }
            else if (counter > counter2 + 20 && deadline >= 0)
            {
                cloud.Render(g, renderer);
                deadline--;
            }
            else if(counter > counter2 + 20)
            {
                ShutdownShowMessage?.Invoke("Program wardeclarer.exe has stopped working\r\nbecause you are fucking capitalist!", "wardeclarer.exe");
            }
            counter++;
        }

        public void SetRenderPanel(frmRenderPanel renderPanel)
        {
            this.renderPanel = renderPanel;
            renderPanel.SetWorldMap(Resources.worldmap);
        }

        public void BeforeRunScript()
        {
            MessageBox.Show("We are warning you that this is not a game\r\n\r\nAre you sure continue?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
