﻿using System;
using System.Collections.Generic;
using System.Drawing;
using WDC.Console;
using WDC.Core;
using WDC.Game;
using WDC.Interface;
using WDC.Localization;
using WDC.Script;
using WDC.UI;
using GarbageClassificationScript.Console;
using GarbageClassificationScript.Properties;
using System.IO;
using System.Linq;

namespace GarbageClassificationScript
{
    public class GarbageClassificationScript : WDCScript, INotifyMessageWhenShutdown
    {
        private localizedStringsLoader localizedStringsLoader;

		private int winWidth;
        private int winHeight;
        private GDISpriteButton box1;
        private GDISpriteButton box2;
		private GDISpriteButton box3;
        private GDISpriteButton box4;

		private GDIStaticText txtScoreLabel;
        private GDIStaticText txtScoreValue;
        private GDIStaticText txtGarbageCurrent;
        private GDIStaticText txtGarbageCurrentAnswer;
        private GDIStaticText text1;
        private GDIStaticText text2;
        private GDIStaticText text3;
        private GDIStaticText text4;
        private GDIStaticText text5;
        private int score;
        private List<GarbageData> garbages;
        private GarbageData currentGarbage = null;
        public event Action<string, string, bool> ShutdownShowMessage;
        private Random rand;
        private int delay;

        private bool started = false;
        private int counter = 0;
        private bool waitingForInput = false;
        private int currentResult;
        private GameObject lastGameObject;
        private bool showCurrentAnswer;
        private Dictionary<string, bool> dic;

        private bool showTooltip;
        private string tooltip;
        private Point tooltipLoc;

        public string Icon
        {
            get { return null; }
        }

        public GarbageClassificationScript()
        {
            dic = new Dictionary<string, bool>();
        }

        public void Init(Engine engine)
        {
            engine.ChangeBackground(Resources.background);

			localizedStringsLoader = new localizedStringsLoader(
				Path.Combine(Environment.CurrentDirectory,
				"Data/GarbageClassificationScript/Localization/strings.xml"));

			score = 100;
			garbages = new List<GarbageData>()
			{
				new GarbageData(){ Name = localizedStringsLoader.FindText("str_pig_bones", engine.Locale), Description = localizedStringsLoader.FindText("str_pig_bones_desc", engine.Locale), Box = GarbageBox.Box1 },
				new GarbageData(){ Name = localizedStringsLoader.FindText("str_rotten_apples", engine.Locale), Description = localizedStringsLoader.FindText("str_rotten_apples_desc", engine.Locale), Box = GarbageBox.Box1 },
				new GarbageData(){ Name = localizedStringsLoader.FindText("str_used_battery", engine.Locale), Description = localizedStringsLoader.FindText("str_used_battery_desc", engine.Locale), Box = GarbageBox.Box4 },
				new GarbageData(){ Name = localizedStringsLoader.FindText("str_napkins", engine.Locale), Description = localizedStringsLoader.FindText("str_napkins_desc", engine.Locale), Box = GarbageBox.Box3 },
				new GarbageData(){ Name = localizedStringsLoader.FindText("str_plastic_bottle", engine.Locale), Description = localizedStringsLoader.FindText("str_plastic_bottle_desc", engine.Locale), Box = GarbageBox.Box2 },
			};
			rand = new Random(10);

			winHeight = Engine.Instance.WinHeight;
            winWidth = Engine.Instance.WinWidth;

            string readyText = localizedStringsLoader.FindText("str_ready", engine.Locale);
            string goText = localizedStringsLoader.FindText("str_go", engine.Locale);
            string pleaseChooseText = localizedStringsLoader.FindText("str_please_choose", engine.Locale);
            string wrongText = localizedStringsLoader.FindText("str_wrong", engine.Locale);
            string correctText = localizedStringsLoader.FindText("str_correct", engine.Locale);

            text1 = new GDIStaticText(readyText, "Arial", 48, Brushes.White, new PointF(0, winHeight - 8), true);
            text2 = new GDIStaticText(goText, "Arial", 40, Brushes.White, new PointF(0, winHeight - 10), true);
            text3 = new GDIStaticText(pleaseChooseText, "Arial", 40, Brushes.White, new PointF(0, winHeight - 10), true);
            text4 = new GDIStaticText(wrongText, "Arial", 40, Brushes.Red, new PointF(0, winHeight - 10), true);
            text5 = new GDIStaticText(correctText, "Arial", 40, Brushes.Green, new PointF(0, winHeight - 10), true);

            box1 = new GDISpriteButton(Resources.box_1, Resources.box_1_hover, new PointF(0.15f, 0.65f), UIMetrics.Relative);
            box2 = new GDISpriteButton(Resources.box_2, Resources.box_2_hover, new PointF(0.35f, 0.65f), UIMetrics.Relative);
            box3 = new GDISpriteButton(Resources.box_3, Resources.box_3_hover, new PointF(0.55f, 0.65f), UIMetrics.Relative);
            box4 = new GDISpriteButton(Resources.box_4, Resources.box_4_hover, new PointF(0.75f, 0.65f), UIMetrics.Relative);
            box1.Metrics = UIMetrics.Relative;
            box2.Metrics = UIMetrics.Relative;
            box3.Metrics = UIMetrics.Relative;
            box4.Metrics = UIMetrics.Relative;

            box1.ShowToolTip= true;
            box2.ShowToolTip= true;
            box3.ShowToolTip= true;
            box4.ShowToolTip= true;
            box1.Tooltip = localizedStringsLoader.FindText("str_kitchen_garbage",Engine.Instance.Locale);
            box2.Tooltip = localizedStringsLoader.FindText("str_recyclables", Engine.Instance.Locale);
            box3.Tooltip = localizedStringsLoader.FindText("str_other_garbage", Engine.Instance.Locale);
            box4.Tooltip = localizedStringsLoader.FindText("str_hazardous_garbage", Engine.Instance.Locale);

            box1.ShowToolTipEvent += ShowToolTipEvent;
            box2.ShowToolTipEvent += ShowToolTipEvent;
            box3.ShowToolTipEvent += ShowToolTipEvent;
            box4.ShowToolTipEvent += ShowToolTipEvent;

            string scoreText = localizedStringsLoader.FindText("str_score", engine.Locale);
			string currentText = localizedStringsLoader.FindText("str_current", engine.Locale);
			string AnswerText = localizedStringsLoader.FindText("str_answer", engine.Locale);

			txtScoreLabel = new GDIStaticText(scoreText, "黑体", 55, Brushes.Black, new PointF(0.63f, 0.11f), false, AlignMethod.PERCENT);
            txtScoreValue = new GDIStaticText("--", "黑体", 55, Brushes.Green, new PointF(0.82f, 0.11f), false, AlignMethod.PERCENT);
            txtScoreLabel.Metrics = UIMetrics.Relative;
            txtScoreValue.Metrics = UIMetrics.Relative;

            txtGarbageCurrent = new GDIStaticText(currentText, "黑体", 55, Brushes.Black, new PointF(340, 90), false, AlignMethod.PERCENT);
            txtGarbageCurrentAnswer = new GDIStaticText(AnswerText, "黑体", 50, Brushes.Black, new PointF(94, 200), false, AlignMethod.PERCENT);


            box1.MouseClicked += Box1_MouseClicked;
			box2.MouseClicked += Box2_MouseClicked;
			box3.MouseClicked += Box3_MouseClicked;
			box4.MouseClicked += Box4_MouseClicked;

            engine.GameObjects.Add(box1);
            engine.GameObjects.Add(box2);
            engine.GameObjects.Add(box3);
            engine.GameObjects.Add(box4);
            engine.GameObjects.Add(txtScoreLabel);
            engine.GameObjects.Add(txtScoreValue);

            ConsoleCommandManager.Instance.AddConsoleCommand(new CheatShowAnswerConsoleCommand());
            ConsoleCommandManager.Instance.AddConsoleCommand(new EnableCheatConsoleCommand());
        }

        private void ShowToolTipEvent(string objectID, bool showTooltip, string tooltip, Point tooltipLoc)
        {
            if (showTooltip)
            {
                this.showTooltip = showTooltip;
                this.tooltip = tooltip;
                this.tooltipLoc = tooltipLoc;
            }

            dic[objectID] = showTooltip;
        }

        private void Box1_MouseClicked(GameObject sender)
        {
            if(!started)
			{
                return;
			}
            waitingForInput = false;
            CheckIsCorrect(0);
        }

        private void Box2_MouseClicked(GameObject sender)
        {
            if (!started)
            {
                return;
            }
            waitingForInput = false;
            CheckIsCorrect(1);
        }

        private void Box3_MouseClicked(GameObject sender)
        {
            if (!started)
            {
                return;
            }
            waitingForInput = false;
            CheckIsCorrect(2);
        }

        private void Box4_MouseClicked(GameObject sender)
        {
            if (!started)
            {
                return;
            }
            waitingForInput = false;
            CheckIsCorrect(3);
        }

		public void Render(Graphics g, IRenderer renderer)
        {
            if (dic.Where(o => o.Value).Count() > 0)
            {
                using (Font font = new Font("Arial", 14))
                {
                    Size tooltipSize = new Size(180, 50);

                    Rectangle rectangle = new Rectangle(tooltipLoc, tooltipSize);
                    if (tooltipLoc.X + tooltipSize.Width > Engine.Instance.WinWidth)
                    {
                        rectangle = new Rectangle(new Point(tooltipLoc.X - tooltipSize.Width, tooltipLoc.Y), tooltipSize);
                    }

                    g.FillRectangle(new SolidBrush(Color.Yellow), rectangle);
                    g.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2), rectangle);
                    g.DrawString(tooltip, font, new SolidBrush(Color.Black), rectangle);
                }
            }

            if (counter >= 0 && counter <= 35)
            {
                //Ready
                text1.Draw(g);

                box1.Enabled = false;
                box2.Enabled = false;
                box3.Enabled = false;
                box4.Enabled = false;
            }
            else if (counter > 35 && counter <= 70)
            {
                //Go!
                text2.Draw(g);
                started = true;

                box1.Enabled = true;
                box2.Enabled = true;
                box3.Enabled = true;
                box4.Enabled = true;
            }
            else if (score <= 0)
            {
                string gameTitle = localizedStringsLoader.FindText("str_game_title", Engine.Instance.Locale);
                string gameOverText = localizedStringsLoader.FindText("str_game_over", Engine.Instance.Locale);
                ShutdownShowMessage?.Invoke(gameOverText, gameTitle, true);
            }
            else if (waitingForInput)
            {
                txtGarbageCurrent.Text = /*string.Format(localizedStringsLoader.FindText("str_current_0", Engine.Instance.Locale), */currentGarbage.Name/*)*/;
                txtGarbageCurrent.Draw(g);
                text3.Draw(g);

                if (showCurrentAnswer)
                {
                    txtGarbageCurrentAnswer.Text = string.Format(localizedStringsLoader.FindText("str_answer_select_0", Engine.Instance.Locale), ((int)currentGarbage.Box) + 1);
                    txtGarbageCurrentAnswer.Draw(g);
                }
            }
            else if (currentResult != 0)
            {
                if (currentResult == 1)
                {
                    text5.Draw(g);
                    lastGameObject = text5;
                    delay = 10;
                    currentResult = 0;

                }
                else if (currentResult == 2)
                {
                    text4.Draw(g);
                    lastGameObject = text4;
                    delay = 10;
                    currentResult = 0;
                }
            }
            else if (delay > 0)
            {
                if (lastGameObject != null)
                {
                    lastGameObject.Render(g, renderer);
                }
                delay--;
            }
            else
            {
                int randIndex = rand.Next(0, garbages.Count);
                currentGarbage = garbages[randIndex];
                waitingForInput = true;

                txtScoreValue.Text = score.ToString();
            }
            counter++;
        }

        public void ShowCurrentAnswer()
        {
            showCurrentAnswer = true;
        }

        internal void HideCurrentAnswer()
        {
            showCurrentAnswer = false;
        }

        public void BeforeRunScript()
        {
        }

        private void CheckIsCorrect(int selectIndex)
        {
            if (currentGarbage == null)
            {
                return;
            }
            if (((int)currentGarbage.Box) == selectIndex)
            {
                currentResult = 1;
                score += 5;
            }
			else
			{
                currentResult = 2;
                score -= 5;
            }
        }

		public void MouseClicked(int x, int y)
		{
		}

		public void MouseMoved(int x, int y)
		{
		}
	}
}
