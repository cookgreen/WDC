using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;
using WDC.Xml;

namespace WDC.Game
{
	public class AnimatedSprite : GameObject
	{
		private Dictionary<string, AnimatedSpriteSequence> sequences;
		private AnimatedSpriteTimer timer;
		private AnimatedSpriteSequence currentSequence;
		private SpriteMovement movement;

		public AnimatedSprite(Bitmap allFramesBitmap, AnimatedSpriteInfo animatedSpriteInfos, PointF position)
		{
			sequences = new Dictionary<string, AnimatedSpriteSequence>();
			timer = new AnimatedSpriteTimer();

			Graphics g = Graphics.FromImage(allFramesBitmap);
			for (int i = 0; i < animatedSpriteInfos.AnimatedSpriteSequences.Count; i++)
			{
				List<Sprite> sprites = new List<Sprite>();

				for (int j = 0; j < animatedSpriteInfos.AnimatedSpriteSequences[i].Regions.Count; j++)
				{
					Bitmap bitmap = new Bitmap(
						animatedSpriteInfos.AnimatedSpriteSequences[i].Regions[j].Width, 
						animatedSpriteInfos.AnimatedSpriteSequences[i].Regions[j].Height);
					g.DrawImage(bitmap, 
						animatedSpriteInfos.AnimatedSpriteSequences[i].Regions[j].OffsetX, 
						animatedSpriteInfos.AnimatedSpriteSequences[i].Regions[j].OffsetY);

					Sprite sprite = new Sprite(bitmap, position);
					sprites.Add(sprite);
				}

				AnimatedSpriteSequence frameSequence = new AnimatedSpriteSequence(animatedSpriteInfos.AnimatedSpriteSequences[i].Length, sprites);
				sequences.Add(animatedSpriteInfos.AnimatedSpriteSequences[i].Name, frameSequence);
			}

			currentSequence = sequences.ElementAt(0).Value;
		}

		public void SetSteering(SpriteMovement movement)
        {
			this.movement = movement;
        }

		public override void Render(Graphics g, IRenderer renderer)
		{
			currentSequence.Render(g, renderer);

			timer.Update();
		}
	}

	public class AnimatedSpriteSequence
	{
		private int curInternalTime = 0;
		private float time;
		private List<Sprite> sprites;
		private Sprite currentSprite;
		private PointF position;
		private bool hasBeenSet;

		private int initDelayTime = 100;
		private int curDelayTime = 0;

		public float Time { get { return time; } }
		public List<Sprite> Sprites { get { return sprites; } }

		public AnimatedSpriteSequence(float time, List<Sprite> sprites)
		{
			this.time = time;
			this.sprites = sprites;
			currentSprite = sprites[0];
			position = currentSprite.Position;
			hasBeenSet = false;
		}

		public void SetSteering(SpriteMovement movement)
		{
			foreach(var s in sprites)
            {
				s.SetSteering(movement);
            }
		}

		public void Render(Graphics g, IRenderer renderer)
        {
			//Animation Control System

			currentSprite = sprites[curInternalTime];

			if (!hasBeenSet)
			{
				currentSprite.Position = sprites[curInternalTime - 1].Position;
				hasBeenSet = true;
			}

			currentSprite.Render(g, renderer);

			if (curDelayTime == initDelayTime)
			{
				if (curInternalTime == sprites.Count - 1)
				{
					curInternalTime = 0;
					hasBeenSet = false;
				}
				else
				{
					curInternalTime++;
					hasBeenSet = false;
				}

				curDelayTime = 0;
			}
            else
            {
				curDelayTime++;
            }
		}
	}
}
