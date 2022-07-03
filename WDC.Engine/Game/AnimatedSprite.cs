using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.Game
{
	public class AnimatedSpriteSequenceInfo
	{
		private string animName;
		private float time;
		private List<Rectangle> region;

		public string AnimName { get { return animName; } }
		public List<Rectangle> Region { get { return region; } }
		public float Time { get { return time; } }

		public AnimatedSpriteSequenceInfo(string animName, List<Rectangle> region, float time)
		{
			this.animName = animName;
			this.region = region;
			this.time = time;
		}
	}


	public class AnimatedSprite : GameObject
	{
		private Dictionary<string, AnimatedSpriteSequence> sequences;
		private AnimatedSpriteTimer timer;
		private AnimatedSpriteSequence currentSequence;

		public AnimatedSprite()
		{
			sequences = new Dictionary<string, AnimatedSpriteSequence>();
		}

		public AnimatedSprite(Bitmap allFramesBitmap, List<AnimatedSpriteSequenceInfo> animatedSpriteInfos, PointF position)
		{
			sequences = new Dictionary<string, AnimatedSpriteSequence>();
			timer = new AnimatedSpriteTimer();

			Graphics g = Graphics.FromImage(allFramesBitmap);
			for (int i = 0; i < animatedSpriteInfos.Count; i++)
			{
				List<Sprite> sprites = new List<Sprite>();

				for (int j = 0; j < animatedSpriteInfos[i].Region.Count; j++)
				{
					Bitmap bitmap = new Bitmap(animatedSpriteInfos[i].Region[j].Width, animatedSpriteInfos[i].Region[j].Height);
					g.DrawImage(bitmap, animatedSpriteInfos[i].Region[j].X, animatedSpriteInfos[i].Region[j].Y);

					Sprite sprite = new Sprite(bitmap, position);
					sprites.Add(sprite);
				}

				AnimatedSpriteSequence frameSequence = new AnimatedSpriteSequence(animatedSpriteInfos[i].Time, sprites);
				sequences.Add(animatedSpriteInfos[i].AnimName, frameSequence);
			}

			currentSequence = sequences.ElementAt(0).Value;
		}

		public override void Render(Graphics g, IRenderer renderer)
		{
			currentSequence.Render(g, renderer);

			timer.Update();
		}
	}

	public class AnimatedSpriteSequence
	{
		private float time;
		private List<Sprite> sprites;

		public float Time { get { return time; } }
		public List<Sprite> Sprites { get { return sprites; } }
		
		public AnimatedSpriteSequence(float time, List<Sprite> sprites)
		{
			this.time = time;
			this.sprites = sprites;
		}

		public void Render(Graphics g, IRenderer renderer)
        {
			sprite.Render(g, renderer);
        }
	}
}
