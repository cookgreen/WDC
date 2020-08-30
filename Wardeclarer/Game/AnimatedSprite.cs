using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wardeclarer.Core;

namespace Wardeclarer.Game
{
	public class AnimatedSpriteInfo
	{
		private Rectangle region;
		private float time;
		public Rectangle Region { get { return region; } }
		public float Time { get { return time; } }

		public AnimatedSpriteInfo(Rectangle region, float time)
		{
			this.region = region;
			this.time = time;
		}
	}


	public class AnimatedSprite : GameObject
	{
		private List<AnimatedFrameSprite> frames;
		private AnimatedSpriteTimer timer;
		public AnimatedSprite()
		{
			frames = new List<AnimatedFrameSprite>();
		}

		public AnimatedSprite(Bitmap allFramesBitmap, List<AnimatedSpriteInfo> animatedSpriteInfos, PointF position)
		{
			frames = new List<AnimatedFrameSprite>();
			timer = new AnimatedSpriteTimer();

			Graphics g = Graphics.FromImage(allFramesBitmap);
			for (int i = 0; i < animatedSpriteInfos.Count; i++)
			{
				Bitmap bitmap = new Bitmap(animatedSpriteInfos[i].Region.Width, animatedSpriteInfos[i].Region.Height);
				g.DrawImage(bitmap, animatedSpriteInfos[i].Region.X, animatedSpriteInfos[i].Region.Y);
				Sprite sprite = new Sprite(bitmap, position);
				AnimatedFrameSprite frameSprite = new AnimatedFrameSprite(animatedSpriteInfos[i].Time, sprite);
				frames.Add(frameSprite);
			}

			frames = (from frame in frames
					  orderby frame.Time
					  select frame).ToList();
		}

		public override void Render(Graphics g, IRenderer renderer)
		{
			int time = timer.CurrentTime;

			var frameNeededRendered = frames.Where(o => o.Time == time).FirstOrDefault();
			if (frameNeededRendered != null)
			{
				frameNeededRendered.Sprite.Render(g, renderer);
			}

			timer.Update();
		}
	}

	public class AnimatedFrameSprite
	{
		private float time;
		private Sprite sprite;
		public float Time { get { return time; } }
		public Sprite Sprite { get { return sprite; } }
		public AnimatedFrameSprite(float time, Sprite sprite)
		{
			this.time = time;
			this.sprite = sprite;
		}
	}
}
