using System;
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
        private PointF missileShootEndPosition = new PointF();
		private PointF missileShootStartPosition = new PointF(743, 134);
        private PointF missileShootEndPositionUSA = new PointF(153, 169);
        private PointF missileShootEndPositionGermany = new PointF(417, 161);
        private int missileShootTolerance = 15;
        private int winHeight;
        private GDIStaticText txtGreeting;
        private GDIStaticText txtChooseCountry;
        private GDIStaticText txtOK;
        private GDISelectableOption optUSA;
        private GDISelectableOption optGermany;
        private List<GDISelectableOption> options;
        private Sprite missile;
        private Sprite cloud;
        private bool clicked;
        private bool reached;
        private Engine engine;
        private SpriteMovement spriteMovement;

        public event Action<string, string, bool> ShutdownShowMessage;

        public string Icon
        {
            get { return null; }
        }

        public WardeclarerScript()
        {
        }

        public void Init(Engine engine)
        {
            engine.ChangeBackground(Resources.worldmap);

            winHeight = Engine.Instance.WinHeight;
            clicked = false;
            reached = false;
            
            txtGreeting = new GDIStaticText("Hello Comrade", "Arial", 50, Brushes.White, new PointF(0, winHeight), true);
            txtChooseCountry = new GDIStaticText("Which country do you wanna destroy today?", "Arial", 40, Brushes.White, new PointF(0, winHeight), true);
            txtOK = new GDIStaticText("OK", "Arial", 60, Brushes.White, new PointF(0, winHeight), true);
            
            options = new List<GDISelectableOption>();
            
            optUSA = new GDISelectableOption("a:) USA[imperialists]", "Arial", 40, Brushes.White, new PointF(0, winHeight), ref options, true);
            optGermany = new GDISelectableOption("b:) Germany[Nazis]", "Arial", 40, Brushes.White, new PointF(0, winHeight), ref options, true);
			
            options.Add(optUSA);
			options.Add(optGermany);
            for (int i = 0; i < options.Count; i++)
            {
                options[i].Position = new PointF(0, winHeight - ((options.Count - i) * options[i].Height));
            }

			float ratio = (float)winHeight / (float)1080;
            
            missileShootStartPosition = new PointF(missileShootStartPosition.X * ratio, missileShootStartPosition.Y * ratio);
            missileShootEndPositionUSA = new PointF(missileShootEndPositionUSA.X * ratio, missileShootEndPositionUSA.Y * ratio);
            missileShootEndPositionGermany = new PointF(missileShootEndPositionGermany.X * ratio, missileShootEndPositionGermany.Y * ratio);
            missileShootTolerance = (int)(missileShootTolerance * ratio);

            missile = new Sprite("missile", Resources.missile, missileShootStartPosition, AlignMethod.CENTER, 0.8f);
			spriteMovement = new SpriteAxisMovement(
				SpriteAxisMovementType.MovementByXAxis,
				SpriteMovementDirection.Left,
				missileShootStartPosition,
				missileShootEndPosition, 10, 5);
			missile.SetSteering(spriteMovement);
			missile.DestReached += Sprite_DestReached;

			optUSA.MouseClicked += Option1_MouseClicked;
			optGermany.MouseClicked += Option2_MouseClicked;
            this.engine = engine;
        }

		private void Option1_MouseClicked(GameObject sender)
        {
            counter2 = counter;
            clicked = true;
            
            missileShootEndPosition = missileShootEndPositionUSA;
            missile.Movement.SetDestPosition(missileShootEndPosition);
			
            cloud = new Sprite("explosive_cloud", Resources.nuclear_boom, missileShootEndPosition, AlignMethod.BOTTOM, 0.6f);
            
            engine.GameObjects.Remove(optUSA);
            engine.GameObjects.Remove(optGermany);
        }

        private void Option2_MouseClicked(GameObject sender)
        {
            counter2 = counter;
            clicked = true;
            
            missileShootEndPosition = missileShootEndPositionGermany;
			missile.Movement.SetDestPosition(missileShootEndPosition);
			
            cloud = new Sprite("explosive_cloud", Resources.nuclear_boom, missileShootEndPosition, AlignMethod.BOTTOM, 0.6f);
            
            engine.GameObjects.Remove(optUSA);
            engine.GameObjects.Remove(optGermany);
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
                txtGreeting.Draw(g);
            }
            else if (counter > 35 && counter <= 70)
            {
                //Which country do you wanna destroy today
                txtChooseCountry.Draw(g);
            }
            else if (!clicked)
            {
                engine.AddIfNotExisted(optUSA);
                engine.AddIfNotExisted(optGermany);
            }
            else if (counter > counter2 && counter <= counter2 + 20)
            {
                txtOK.Draw(g);
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
                ShutdownShowMessage?.Invoke("Program wardeclarer.exe has stopped working\r\nbecause you are a fucking capitalist dog!", "wardeclarer.exe", true);
            }
            counter++;
        }

        public void BeforeRunScript()
        {
            MessageBox.Show("We are warning you that this is not a game\r\n\r\nAre you sure continue?", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

		public void MouseClicked(int x, int y)
		{
		}

		public void MouseMoved(int x, int y)
		{
		}
	}
}
