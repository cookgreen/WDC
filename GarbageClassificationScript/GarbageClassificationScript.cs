using System;
using System.Collections.Generic;
using System.Drawing;
using WDC;
using WDC.Game;
using WDC.UI;
using WDC.Interface;
using GarbageClassificationScript.Properties;
using System.Windows.Forms;
using WDC.Core;
using GarbageClassificationScript;
using WDC.Script;
using WDC.Console;
using GarbageClassificationScript.Console;
using WDC.Locate;

namespace GarbageClassificationScript
{
	public class GarbageClassificationScript : WDCScript, INotifyMessageWhenShutdown
    {
        private frmRenderPanel renderPanel;
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
        public event Action<string, string> ShutdownShowMessage;
        private Random rand;
        private int delay;

        private bool started = false;
        private int counter = 0;
        private bool waitingForInput = false;
        private int currentResult;
        private GameObject lastGameObject;
        private bool showCurrentAnswer;

        public GarbageClassificationScript()
        {
            score = 100;
            garbages = new List<GarbageData>()
            {
                new GarbageData(){ Name="猪骨头", Description = "吃剩的猪骨头", Box = GarbageBox.Box1 },
                new GarbageData(){ Name="苹果核", Description = "吃剩的苹果核", Box = GarbageBox.Box1 },
                new GarbageData(){ Name="废旧电池", Description = "用完的电池", Box = GarbageBox.Box4 },
                new GarbageData(){ Name="餐巾纸", Description = "使用过的餐巾纸", Box = GarbageBox.Box3 },
                new GarbageData(){ Name="塑料瓶", Description = "用完的塑料瓶", Box = GarbageBox.Box2 },
            };
            rand = new Random(10);
        }

        public void Init(Engine engine)
        {
            winHeight = Engine.WinHeight;
            winWidth = Engine.WinWidth;

            text1 = new GDIStaticText("准备", "Baskerville Old Face", 50, Brushes.White, new PointF(0, winHeight), true);
            text2 = new GDIStaticText("Go!", "Baskerville Old Face", 40, Brushes.White, new PointF(0, winHeight), true);
            text3 = new GDIStaticText("请选择!", "Baskerville Old Face", 40, Brushes.White, new PointF(0, winHeight), true);
            text4 = new GDIStaticText("答错了!", "Baskerville Old Face", 40, Brushes.Red, new PointF(0, winHeight), true);
            text5 = new GDIStaticText("回答正确!", "Baskerville Old Face", 40, Brushes.Green, new PointF(0, winHeight), true);

            box1 = new GDISpriteButton(Resources.box_1, Resources.box_1_hover, new PointF(0.15f, 0.6f));
            box2 = new GDISpriteButton(Resources.box_2, Resources.box_2_hover, new PointF(0.35f, 0.6f));
            box3 = new GDISpriteButton(Resources.box_3, Resources.box_3_hover, new PointF(0.55f, 0.6f));
            box4 = new GDISpriteButton(Resources.box_4, Resources.box_4_hover, new PointF(0.75f, 0.6f));
            box1.Metrics = UIMetrics.Relative;
            box2.Metrics = UIMetrics.Relative;
            box3.Metrics = UIMetrics.Relative;
            box4.Metrics = UIMetrics.Relative;

            txtScoreLabel = new GDIStaticText("分数:", "Baskerville Old Face", 55, Brushes.White, new PointF(0.7f, 0.12f), false, AlignMethod.FLOATING);
            txtScoreValue = new GDIStaticText("--", "Baskerville Old Face", 55, Brushes.White, new PointF(0.85f, 0.12f), false, AlignMethod.FLOATING);
            txtScoreLabel.Metrics = UIMetrics.Relative;
            txtScoreValue.Metrics = UIMetrics.Relative;

            txtGarbageCurrent = new GDIStaticText("当前:", "Baskerville Old Face", 55, Brushes.White, new PointF(94, 90), false, AlignMethod.FLOATING);
            txtGarbageCurrentAnswer = new GDIStaticText("答案:", "Baskerville Old Face", 50, Brushes.White, new PointF(94, 200), false, AlignMethod.FLOATING);


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

		private void Box1_MouseClicked()
        {
            if(!started)
			{
                return;
			}
            waitingForInput = false;
            CheckIsCorrect(0);
        }

        private void Box2_MouseClicked()
        {
            if (!started)
            {
                return;
            }
            waitingForInput = false;
            CheckIsCorrect(1);
        }

        private void Box3_MouseClicked()
        {
            if (!started)
            {
                return;
            }
            waitingForInput = false;
            CheckIsCorrect(2);
        }

        private void Box4_MouseClicked()
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
            if (counter >= 0 && counter <= 35)
            {
                //Ready
                text1.Draw(g);
            }
            else if (counter > 35 && counter <= 70)
            {
                //Go!
                text2.Draw(g);
                started = true;
            }
            else if (score <= 0)
            {
                ShutdownShowMessage?.Invoke("游戏结束!", "wardeclarer.exe");
            }
            else if (waitingForInput)
            {
                txtGarbageCurrent.Text = "当前: " + currentGarbage.Name;
                txtGarbageCurrent.Draw(g);
                text3.Draw(g);

                if (showCurrentAnswer)
                {
                    txtGarbageCurrentAnswer.Text = "答案: 选择第" + (((int)currentGarbage.Box) + 1).ToString() +"个";
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

        public void SetRenderPanel(frmRenderPanel renderPanel)
        {
            this.renderPanel = renderPanel;
            renderPanel.SetWorldMap(Resources.worldmap);
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
    }
}
