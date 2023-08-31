using DefendCastleScript.Properties;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using WDC.Core;
using WDC.Game;
using WDC.Script;
using WDC.UI;
using WDC.Xml;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Media;
using WDC.Expression;
using System.Numerics;

namespace DefendCastleScript
{
    enum DeviceCap
    {
        VERTRES = 10,
        PHYSICALWIDTH = 110,
        SCALINGFACTORX = 114,
        DESKTOPVERTRES = 117,
		DESKTOPHORZRES = 118,
	}

    public class DefendCastleScript : WDCScript
    {
        [DllImport("gdi32.dll", EntryPoint = "GetDeviceCaps", SetLastError = true)]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        private SoundPlayer soundPlayer;
        private SoundPlayer environmentPlayer;

        private string scriptSoundDataDir;
        private Random random;
        private int currentLevel = 1;
        private bool levelStarted = false;
        private bool activeCounterdown = true;
        private int power = 1;
        private bool powerEnabled = false;

        private Dictionary<int, Dictionary<string, string>> levelData = new Dictionary<int, Dictionary<string, string>>
        {
            { 1, new Dictionary<string, string>
                {
                    {"enemyType", "Spearman|5" }
                }
            },
            { 2, new Dictionary<string, string>
                {
                    {"enemyType", "Spearman|15" }
                }
            },
            { 3, new Dictionary<string, string>
                {
                    {"enemyType", "Spearman|10,Knight|5" }
                }
            },
            { 4, new Dictionary<string, string>
                {
                    {"enemyType", "Spearman|15,Knight|10" }
                }
            },
            { 5, new Dictionary<string, string>
                {
                    {"enemyType", "Spearman|20,Knight|10" }
                }
            },
            { 6, new Dictionary<string, string>
                {
                    {"enemyType", "Spearman|5,Knight|5,Crossbowman|2" }
                }
            },
            { 7, new Dictionary<string, string>
                {
                    {"enemyType", "Spearman|10,Knight|5,Crossbowman|3" }
                }
            },
            { 8, new Dictionary<string, string>
                {
                    {"enemyType", "Spearman|5, Knight|10, Crossbowman|5" }
                }
            },
            { 9, new Dictionary<string, string>
                {
                    {"enemyType", "Spearman|5,Knight|5,Crossbowman|10" }
                }
            },
            { 10, new Dictionary<string, string>
                {
                    {"enemyType", "Spearman|15,Knight|10,Crossbowman|5" }
                }
            },
        };
        private float time = 0;
        
        private GDIStaticText lbCounterdownNotice;
        private GDIStaticText lbLevelTitle;
        private GDIStaticText lbGameOver;
		private GDIStaticText lbPower;

		private List<Actor> enemies = new List<Actor>();
        private List<Actor> defenderArchers = new List<Actor>();

        private string spearmanSpriteSheetBitmapFile;
        private string knightSpriteSheetBitmapFile;
        private string crossbowmanSpriteSheetBitmapFile;
        private string arrowSpriteBitmapFile;

        private AnimatedSpriteInfo spearmanSpriteInfo;
        private AnimatedSpriteInfo knightSpriteInfo;
        private AnimatedSpriteInfo crossbowmanSpriteInfo;
        private float castleGateHP = 500;

        private int initCounterdown = 10;
        private int curCounterdown = 10;

        private int initDelay = 50;
        private int curDelay = 0;

        private ExpressionParser expressionParser;

        private Dictionary<string, string> enemySpearmanDic = new Dictionary<string, string>()
            {
                { "HP", "VALUE{120}"},
                { "Armour", "VALUE{10}"},
                { "Speed", "RANDOM{1-3}"},
            };
        private Dictionary<string, string> enemyKnightDic = new Dictionary<string, string>()
            {
                { "HP", "VALUE{240}"},
                { "Armour", "VALUE{30}"},
                { "Speed", "RANDOM{10-15}"},
            };
        private Dictionary<string, string> enemyCrossbowmanDic = new Dictionary<string, string>()
            {
                { "HP", "VALUE{180}"},
                { "Armour", "VALUE{17}"},
                { "Speed", "RANDOM{10-15}"},
                { "Damage", "RANDOM{10-15}"},
            };

        private string scriptDataDir;
        private string iconFile;
        private int winWidth;
        private int winHeight;
        private Engine engine;

        //1920x1080
        private PointF archer1Pos = new PointF(1245, 571);
        private PointF archer2Pos = new PointF(1290, 388);
        private PointF archer3Pos = new PointF(1160, 339);
        private PointF archer4Pos = new PointF(1075, 225);

        private PointF enemySpawnPoint = new PointF(10, 690);
        private PointF castleGate1Pos = new PointF(900, 650);
		private PointF castleGate2Pos = new PointF(1000, 725);
		private PointF castleGate3Pos = new PointF(1150, 837);

		public string Icon
        {
            get { return iconFile; }
        }

        public void BeforeRunScript()
        {
        }

        public void Init(Engine engine)
        {
            random = new Random();

            soundPlayer = new SoundPlayer();
            environmentPlayer = new SoundPlayer();

            expressionParser = new ExpressionParser();

            this.engine = engine;

			winWidth = GetDeviceCaps(Graphics.FromHwnd(IntPtr.Zero).GetHdc(), (int)DeviceCap.DESKTOPHORZRES);
			winHeight = GetDeviceCaps(Graphics.FromHwnd(IntPtr.Zero).GetHdc(), (int)DeviceCap.DESKTOPVERTRES);
            engine.ChangeBackground(Resources.CastleBackGround);
            defenderArchers = new List<Actor>();

            float ratio = (float)winHeight / (float)1080;

            //use ratio to adjust all the positions
            archer1Pos = new PointF(archer1Pos.X * ratio, archer1Pos.Y * ratio);
            archer2Pos = new PointF(archer2Pos.X * ratio, archer2Pos.Y * ratio);
            archer3Pos = new PointF(archer3Pos.X * ratio, archer3Pos.Y * ratio);
            archer4Pos = new PointF(archer4Pos.X * ratio, archer4Pos.Y * ratio);

            enemySpawnPoint = new PointF(enemySpawnPoint.X * ratio, enemySpawnPoint.Y * ratio);
            castleGate1Pos = new PointF(castleGate1Pos.X * ratio, castleGate1Pos.Y * ratio);
            castleGate2Pos = new PointF(castleGate2Pos.X * ratio, castleGate2Pos.Y * ratio);
            castleGate3Pos = new PointF(castleGate3Pos.X * ratio, castleGate3Pos.Y * ratio);

            float titleSize = 80 * ratio;


            lbCounterdownNotice = new GDIStaticText("Ready: " + curCounterdown.ToString(), "Arial", (int)titleSize, Brushes.Black, new PointF(0, 0), false, AlignMethod.CENTER);
            lbLevelTitle = new GDIStaticText("LEVEL: " + currentLevel.ToString(), "Arial", (int)titleSize, Brushes.Black, new PointF(0, 0), false, AlignMethod.CENTER);
            lbGameOver = new GDIStaticText("GAME OVER", "Arial", (int)titleSize, Brushes.Red, new PointF(0, 0), false, AlignMethod.CENTER);
            lbPower = new GDIStaticText("Power: " + power.ToString(), "Arial", 15, Brushes.Black, new PointF(0, 0), false, AlignMethod.BOTTOM);

            scriptDataDir = Path.Combine(Environment.CurrentDirectory, "Data\\DefendCastleScript\\");
            string scriptSpriteDataDir = Path.Combine(scriptDataDir, "Sprites");
            string scriptSettingsDataDir = Path.Combine(scriptDataDir, "Settings");
            string scriptIconDataDir = Path.Combine(scriptDataDir, "Icon");
            scriptSoundDataDir = Path.Combine(scriptDataDir, "Sound");

            AnimatedSpriteInfoList animatedSpriteInfoList = AnimatedSpriteInfoList.Parse(Path.Combine(scriptSettingsDataDir, "anim.xml"));

            spearmanSpriteSheetBitmapFile = Path.Combine(scriptSpriteDataDir, "SpearmanSprite.png");
            knightSpriteSheetBitmapFile = Path.Combine(scriptSpriteDataDir, "KnightSprite.png");
            crossbowmanSpriteSheetBitmapFile = Path.Combine(scriptSpriteDataDir, "CrossbowmanSprite.png");
            arrowSpriteBitmapFile = Path.Combine(scriptSpriteDataDir, "arrow.png");

			string archerSpriteSheetBitmapFile = Path.Combine(scriptSpriteDataDir, "ArcherSprite.png");

            spearmanSpriteInfo = animatedSpriteInfoList.AnimatedSprites.Where(o => o.Name == "Spearman").FirstOrDefault();
            knightSpriteInfo = animatedSpriteInfoList.AnimatedSprites.Where(o => o.Name == "Knight").FirstOrDefault();
            crossbowmanSpriteInfo = animatedSpriteInfoList.AnimatedSprites.Where(o => o.Name == "Crossbowman").FirstOrDefault();
            AnimatedSpriteInfo archerSpriteInfo = animatedSpriteInfoList.AnimatedSprites.Where(o => o.Name == "Archer").FirstOrDefault();
            
            AnimatedSprite archer1Sprite = new AnimatedSprite("archer", new Bitmap(archerSpriteSheetBitmapFile), archerSpriteInfo, archer1Pos);
            AnimatedSprite archer2Sprite = new AnimatedSprite("archer", new Bitmap(archerSpriteSheetBitmapFile), archerSpriteInfo, archer2Pos);
            AnimatedSprite archer3Sprite = new AnimatedSprite("archer", new Bitmap(archerSpriteSheetBitmapFile), archerSpriteInfo, archer3Pos);
            AnimatedSprite archer4Sprite = new AnimatedSprite("archer", new Bitmap(archerSpriteSheetBitmapFile), archerSpriteInfo, archer4Pos);

            var defenderArcherDic = new Dictionary<string, string>()
            {
                { "HP", "VALUE{220}"},
                { "Armour", "VALUE{20}"},
                { "Speed", "VALUE{0}"},
                { "Damage", "VALUE{40}"},
                { "PromotionHPRate", "VALUE{0.5}"},
            };
            var defenderArcher1 = new Actor(archer1Sprite, defenderArcherDic);
            var defenderArcher2 = new Actor(archer2Sprite, defenderArcherDic);
            var defenderArcher3 = new Actor(archer3Sprite, defenderArcherDic);
            var defenderArcher4 = new Actor(archer4Sprite, defenderArcherDic);

            defenderArchers.Add(defenderArcher1);
            defenderArchers.Add(defenderArcher2);
            defenderArchers.Add(defenderArcher3);
            defenderArchers.Add(defenderArcher4);

            iconFile = Path.Combine(scriptIconDataDir, "icon.ico");

			engine.MouseUpEvent += MouseUp;
        }

		public void Render(Graphics g, IRenderer renderer)
		{
            lbPower.Text = "Power: " + power.ToString();
			lbPower.Draw(g);

            if(powerEnabled)
            {
                power++;
            }

            if (!levelStarted && activeCounterdown)
            {
                lbCounterdownNotice.Draw(g);
            }
            else if (levelStarted)
            {
                lbLevelTitle.Draw(g);
            }
            else if (enemies.Count == 0)
            {
                stopPlaySound(environmentPlayer);
                playSound(soundPlayer, "level_victory.wav");
                currentLevel++;
                lbLevelTitle.Text = "LEVEL: " + currentLevel.ToString();
                curCounterdown = initCounterdown;
                levelStarted = false;
                activeCounterdown = true;
            }
            else if (castleGateHP == 0) //All defenders are dead or Castle gate has been broken, the game over
            {
                lbGameOver.Draw(g);
            }

            if(!levelStarted && curCounterdown == 0)
            {
                curDelay = 0;
                activeCounterdown = false;
                startNewLevel();
                //playSoundLoop(environmentPlayer, "environment.wav");
            }

            if (curDelay == initDelay && activeCounterdown)
            {
                curCounterdown--;
                curDelay = 0;

                lbCounterdownNotice.Text = "Ready: " + curCounterdown.ToString();
            }
            else
            {
                curDelay++;
            }

            foreach(var defender in defenderArchers)
            {
                defender.Render(g, renderer);
            }
            foreach (var enemy in enemies)
            {
                enemy.Render(g, renderer);
            }

            time++;
        }

        private Actor createActor(GameObject gameObject, Dictionary<string, string> dic)
        {
            return new Actor(gameObject, dic);
        }

        private void playSound(SoundPlayer soundPlayer, string soundFile)
        {
            string soundFullPath = Path.Combine(scriptSoundDataDir, soundFile);
            soundPlayer.SoundLocation = soundFullPath;
            soundPlayer.Play();
        }

        private void playSoundLoop(SoundPlayer soundPlayer, string soundFile)
        {
            string soundFullPath = Path.Combine(scriptSoundDataDir, soundFile);
            soundPlayer.SoundLocation = soundFullPath;
            soundPlayer.PlayLooping();
        }

        private void stopPlaySound(SoundPlayer soundPlayer)
        {
            soundPlayer.Stop();
        }

        private Actor spawnSingleEnemy(string enemyType)
		{
			AnimatedSprite gameObject = null;
            Actor actor = null;

            PointF destPos = new PointF();
			int randX = random.Next(10, 50);
            int randY = 0;

			var randGateNo = random.Next(1, 4);
            switch(randGateNo)
            {
                case 1:
                    randY = random.Next(543, 563);
                    destPos = castleGate1Pos;
					break;
                case 2:
					randY = random.Next(613, 633);
					destPos = castleGate2Pos;
					break;
                case 3:
					randY = random.Next(725, 745);
					destPos = castleGate3Pos;
					break;
            }
			enemySpawnPoint = new PointF(randX, randY);
			
            switch (enemyType)
			{
				case "Spearman":
					gameObject = new AnimatedSprite("spearman", new Bitmap(spearmanSpriteSheetBitmapFile), spearmanSpriteInfo, enemySpawnPoint, AlignMethod.MANUAL);
					actor = createActor(gameObject, enemySpearmanDic);
					break;
				case "Knight":
					gameObject = new AnimatedSprite("knight", new Bitmap(knightSpriteSheetBitmapFile), knightSpriteInfo, enemySpawnPoint, AlignMethod.MANUAL);
					actor = createActor(gameObject, enemyKnightDic);
					break;
				case "Crossbowman":
					gameObject = new AnimatedSprite("crossbowman", new Bitmap(crossbowmanSpriteSheetBitmapFile), crossbowmanSpriteInfo, enemySpawnPoint, AlignMethod.MANUAL);
					actor = createActor(gameObject, enemyCrossbowmanDic);
					break;
			}
			var movement = new SpriteAxisMovement(
                SpriteAxisMovementType.MovementByXAxis, 
                SpriteMovementDirection.Right, 
                actor.Position, destPos, 
                actor.GetActorProperty("Speed"), 5);
			gameObject.SetSteering(movement);
			gameObject.DestReached += GameObjectDestReached;
			return actor;
		}

		private void GameObjectDestReached(AnimatedSprite gameObject)
		{
            if (gameObject.CurrentSequence.Name == "Walk")
            {
                gameObject.ChangeSequence("Attack");
                gameObject.SetSteering(null);
            }
		}

		private void spawnEnemy(string enemyType, int enemyNumber)
        {
			for (int j = 0; j < enemyNumber; j++)
			{
				Actor actor = spawnSingleEnemy(enemyType);
				enemies.Add(actor);
			}
		}

        private void startNewLevel()
        {
            enemies.Clear();
            var enemyData = levelData[currentLevel].ElementAt(0).Value;
            string[] enemyArr = enemyData.Split(',');
            for (int i = 0; i < enemyArr.Length; i++)
            {
                string enemyAr = enemyArr[i];
                string[] enemyDic = enemyAr.Split('|');
                string enemyType = enemyDic[0];
                int enemyNumber = int.Parse(enemyDic[1]);
                spawnEnemy(enemyType, enemyNumber);
            }

            //Play Level Start Sound
            playSound(soundPlayer, "level_start.wav");

            levelStarted = true;
        }

		public void MouseClicked(int x, int y)
		{
            if (defenderArchers.Where(o => !o.IsAlive).Count() == defenderArchers.Count)
                return;

            powerEnabled = true;
		}

		private void MouseUp(int x, int y)
		{
            if (powerEnabled)
            {
                powerEnabled = false;
                power = 1;

				playSound(soundPlayer, "bow_shoot.wav");

				foreach (var defender in defenderArchers)
                {
                    if (!defender.IsAlive)
                        continue;

                    var centerPos = defender.CenterPosition;
                    var angle = Math.Atan((y - centerPos.Y) / (x - centerPos.X));
                    var spriteArrow = new Sprite("arrow", new Bitmap(arrowSpriteBitmapFile), defender.Position);

                    var spriteArrowMovement = new SpriteParabolaMovement(
                        SpriteMovementDirection.Left,
                        angle * -20, 100, -9.8f, centerPos);
                    spriteArrow.SetSteering(spriteArrowMovement);

                    var actorArrow = createActor(spriteArrow, new Dictionary<string, string>() { { "Speed", "15" } });
                    engine.GameObjects.Add(spriteArrow);
                }
            }
		}

		public void MouseMoved(int x, int y)
		{
			if (defenderArchers.Where(o => !o.IsAlive).Count() == defenderArchers.Count)
				return;

			foreach (var defender in defenderArchers)
            {
                if (!defender.IsAlive)
                    continue;

                var centerPos = defender.CenterPosition;
                var angle = Math.Atan((centerPos.Y - y) / (centerPos.X - x));

                if (angle > 0) { ((AnimatedSprite)defender.GameObject).ChangeToSpecificFrame("Shoot", 2); }
                else if (angle < 0) { ((AnimatedSprite)defender.GameObject).ChangeToSpecificFrame("Shoot", 1); }
                else { ((AnimatedSprite)defender.GameObject).ChangeToSpecificFrame("Shoot", 3); }
			}
		}
	}
}
