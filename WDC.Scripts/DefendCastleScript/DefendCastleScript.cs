using DefendCastleScript.Xml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using WDC.Core;
using WDC.Game;
using WDC.Script;
using WDC.Physics;
using WDC.UI;
using WDC.Xml;

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

	public enum LevelStatus
	{
		Ready,
		Initizating,
		Running,
		Stopped
	}

	public class DefendCastleScript : WDCScript
	{
		[DllImport("gdi32.dll", EntryPoint = "GetDeviceCaps", SetLastError = true)]
		public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

		private LevelStatus levelStatus;
		private GameXml gameXml;

		private SoundPlayer soundPlayer;
		private SoundPlayer environmentPlayer;

		private string scriptSoundDataDir;
		private Random random;
		private int currentLevel = 1;
		private float time = 0;

		private GDIStaticText lbCounterdownNotice;
		private GDIStaticText lbLevelTitle;
		private GDIStaticText lbGameOver;

		private List<Actor> enemies = new List<Actor>();
		private List<Actor> defenderArchers = new List<Actor>();

		private string spearmanSpriteSheetBitmapFile;
		private string knightSpriteSheetBitmapFile;
		private string crossbowmanSpriteSheetBitmapFile;
		private string arrowSpriteBitmapFile;

		private AnimatedSpriteInfo spearmanSpriteInfo;
		private AnimatedSpriteInfo knightSpriteInfo;
		private AnimatedSpriteInfo crossbowmanSpriteInfo;

		private int initCounterdown = 10;
		private int curCounterdown = 10;

		private int initDelay = 50;
		private int curDelay = 0;

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
			this.engine = engine;

			levelStatus = LevelStatus.Ready;

			CollideManager.Instance.CollideHappened += CollideHappened;
			ActorHitPointManager.Instance.ActorIsDead += ActorIsDead;
			random = new Random();

			soundPlayer = new SoundPlayer();
			environmentPlayer = new SoundPlayer();

			winWidth = engine.WinWidth;
			winHeight = engine.WinHeight;
			defenderArchers = new List<Actor>();

			float ratio = (float)winHeight / (float)864;

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

			scriptDataDir = Path.Combine(Environment.CurrentDirectory, "Data\\DefendCastleScript\\");
			string scriptSpriteDataDir = Path.Combine(scriptDataDir, "Sprites");
			string scriptSettingsDataDir = Path.Combine(scriptDataDir, "Settings");
			string scriptIconDataDir = Path.Combine(scriptDataDir, "Icon");
			scriptSoundDataDir = Path.Combine(scriptDataDir, "Sound");

			gameXml = GameXml.Parse(Path.Combine(scriptSettingsDataDir, "game.xml"));
			AnimatedSpriteInfoList animatedSpriteInfoList = AnimatedSpriteInfoList.Parse(Path.Combine(scriptSettingsDataDir, gameXml.Art.file));

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

			var defenderArcher1 = new Actor(null, archer1Sprite, gameXml["Archer"].ToDic());
			var defenderArcher2 = new Actor(null, archer2Sprite, gameXml["Archer"].ToDic());
			var defenderArcher3 = new Actor(null, archer3Sprite, gameXml["Archer"].ToDic());
			var defenderArcher4 = new Actor(null, archer4Sprite, gameXml["Archer"].ToDic());

			defenderArchers.Add(defenderArcher1);
			defenderArchers.Add(defenderArcher2);
			defenderArchers.Add(defenderArcher3);
			defenderArchers.Add(defenderArcher4);

			iconFile = Path.Combine(scriptIconDataDir, "icon.ico");

			engine.MouseUpEvent += MouseUp;
		}

		private void ActorIsDead(Actor deadActor, Actor _)
		{
			((AnimatedSprite)deadActor.GameObject).ChangeSequence("Die");
		}

		private void CollideHappened(Actor actor1, Actor actor2)
		{
			if (actor1.GameObject.UID.StartsWith("arrow"))//we only check arrow hit 
			{
				float originalHP = actor2.GetActorProperty("HP");
				float damage = actor1.GetActorProperty("Damage");
				actor2.SetActorPropertyFixedValue("HP", originalHP - damage);
				if (!actor2.IsAlive)
				{
					ActorHitPointManager.Instance.KillActor(actor2, actor1.Parent);
				}
				engine.GameObjects.Remove(actor1.GameObject);//when hit the enemy, the arrow should disappear
			}
		}

		/* WAVE MODE */
		public void Render(Graphics g, IRenderer renderer)
		{
			if (levelStatus == LevelStatus.Initizating)
			{
				curDelay = 0;
				startNewLevel();
				//playSoundLoop(environmentPlayer, "environment.wav");

				lbLevelTitle.Draw(g);

				levelStatus = LevelStatus.Running;
			}
			else if (levelStatus == LevelStatus.Ready)
			{
				if (curCounterdown == 0)
				{
					levelStatus = LevelStatus.Initizating;
				}
				else
				{
					lbCounterdownNotice.Text = "Ready: " + curCounterdown.ToString();
					lbCounterdownNotice.Draw(g);

					if (curDelay == initDelay)
					{
						curCounterdown--;
						curDelay = 0;
					}
					else
					{
						curDelay++;
					}
				}
			}
			else if (levelStatus == LevelStatus.Running)
			{
				if (defenderArchers.Where(o => o.IsAlive).Count() == 0)
				{
					levelStatus = LevelStatus.Stopped;
					//all defender died, game over
					gameOver(g);
				}
				else
				{
					if (enemies.Where(o => o.IsAlive).Count() == 0)
					{
						//all enemies died, start next level
						stopPlaySound(environmentPlayer);
						playSound(soundPlayer, "level_victory.wav");
						currentLevel++;

						lbLevelTitle.Text = "LEVEL: " + currentLevel.ToString();
						curCounterdown = initCounterdown;

						levelStatus = LevelStatus.Ready;
					}
				}

				foreach (var defender in defenderArchers)
				{
					defender.Render(g, renderer);
				}

				foreach (var enemy in enemies)
				{
					enemy.Render(g, renderer);
				}

				time++;

				CollideManager.Instance.Update();
			}
		}

		private void startNewLevel()
		{
			clearEnemies();
			enemies.Clear();
			Engine.Instance.Actors.Clear();
			CollideManager.Instance.ClearAll();

			var levelData = gameXml[currentLevel].LevelData;
			foreach (var level in levelData)
			{
				string enemyType = level.Name;
				int enemyNumber = int.Parse(level.Value);
				spawnEnemy(enemyType, enemyNumber);
			}

			//Play Level Start Sound
			playSound(soundPlayer, "level_start.wav");
		}

		private void clearEnemies()
		{
			foreach (var enemy in enemies)
			{
				engine.Actors.Remove(enemy);
				engine.GameObjects.Remove(enemy.GameObject);
			}
		}

		private void gameOver(Graphics g)
		{
			lbGameOver.Draw(g);
		}

		private void spawnEnemy(string enemyType, int enemyNumber)
		{
			for (int j = 0; j < enemyNumber; j++)
			{
				Actor actor = spawnSingleEnemy(enemyType);
				enemies.Add(actor);
			}
		}

		private Actor spawnSingleEnemy(string enemyType)
		{
			AnimatedSprite gameObject = null;
			Actor actor = null;

			PointF destPos = new PointF();
			int randX = random.Next(10, 50);
			int randY = 0;

			var randGateNo = random.Next(1, 4);
			switch (randGateNo)
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
					gameObject = new AnimatedSprite("spearman",
						new Bitmap(spearmanSpriteSheetBitmapFile),
						spearmanSpriteInfo,
						enemySpawnPoint,
						AlignMethod.MANUAL);
					actor = createActor(gameObject, gameXml["Spearman"].ToDic());
					break;
				case "Knight":
					gameObject = new AnimatedSprite("knight",
						new Bitmap(knightSpriteSheetBitmapFile),
						knightSpriteInfo,
						enemySpawnPoint,
						AlignMethod.MANUAL);
					actor = createActor(gameObject, gameXml["Knight"].ToDic());
					break;
				case "Crossbowman":
					gameObject = new AnimatedSprite("crossbowman",
						new Bitmap(crossbowmanSpriteSheetBitmapFile),
						crossbowmanSpriteInfo,
						enemySpawnPoint,
						AlignMethod.MANUAL);
					actor = createActor(gameObject, gameXml["Crossbowman"].ToDic());
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

		private Actor createActor(GameObject gameObject, Dictionary<string, string> dic)
		{
			return new Actor(null, gameObject, dic);
		}

		private Actor createActorWithParent(Actor parent, GameObject gameObject, Dictionary<string, string> dic)
		{
			return new Actor(parent, gameObject, dic);
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

		private void GameObjectDestReached(AnimatedSprite gameObject)
		{
			if (gameObject.CurrentSequence.Name == "Walk")
			{
				gameObject.ChangeSequence("Attack");
				gameObject.SetSteering(null);
			}
		}

		public void MouseClicked(int x, int y)
		{
		}

		private void MouseUp(int x, int y)
		{
			if (levelStatus == LevelStatus.Running)
			{
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

					var actorArrow = createActorWithParent(defender, spriteArrow, new Dictionary<string, string>());
					engine.GameObjects.Add(spriteArrow);

					CollideManager.Instance.AddCollideCheckRange(actorArrow, enemies);
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