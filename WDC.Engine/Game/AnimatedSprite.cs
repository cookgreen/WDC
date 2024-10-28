using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;
using WDC.UI;
using WDC.Xml;

namespace WDC.Game
{
	public class AnimatedSprite : GameObject
	{
		private Dictionary<string, AnimatedSpriteSequence> sequences;
		private AnimatedSpriteSequence currentSequence;
		private SpriteMovement movement;

		public event Action<string> SequenceFinished;
		public event Action<AnimatedSprite> DestReached;
		public Anchor Anchor { get; set; }

		public AnimatedSpriteSequence CurrentSequence
		{
			get { return currentSequence; }
		}
		public override PointF Position
		{
			get { return currentSequence.Position; }
			set
			{
				foreach (var seq in sequences)
				{
					seq.Value.Position = value;
				}
			}
		}

		public override SizeF Size
		{
			get { return currentSequence.Size; }
			set
			{
				foreach(var seq in sequences)
				{
					seq.Value.Size = value;
				}
			}
		}

		public AnimatedSprite(
			string typeName,
			Bitmap allFramesBitmap, 
			AnimatedSpriteInfo animatedSpriteInfos, 
			PointF position,
			AlignMethod align = AlignMethod.CENTER,
			float scale = 1f,
			Anchor anchor = Anchor.LeftTop) : base(typeName)
		{
			this.position = position;

			sequences = new Dictionary<string, AnimatedSpriteSequence>();

			for (int i = 0; i < animatedSpriteInfos.AnimatedSpriteSequences.Count; i++)
			{
				List<Sprite> sprites = new List<Sprite>();

				for (int j = 0; j < animatedSpriteInfos.AnimatedSpriteSequences[i].Regions.Count; j++)
				{
					var region = animatedSpriteInfos.AnimatedSpriteSequences[i].Regions[j];

					Bitmap newImage = new Bitmap(region.Width, region.Height);
					using (Graphics g = Graphics.FromImage(newImage))
					{
						g.DrawImage(
							allFramesBitmap,
							new Rectangle(0, 0, region.Width, region.Height),
							new RectangleF(
								region.OffsetX,
								region.OffsetY,
								region.Width,
								region.Height),
							GraphicsUnit.Pixel
						);
					}
					Anchor = anchor;
					Sprite sprite = new Sprite(typeName, newImage, position, align, scale);
					sprite.Anchor = anchor;
					sprites.Add(sprite);
				}

				AnimatedSpriteSequence frameSequence = new AnimatedSpriteSequence(
					animatedSpriteInfos.AnimatedSpriteSequences[i].Name,
					animatedSpriteInfos.AnimatedSpriteSequences[i].Length,
					animatedSpriteInfos.AnimatedSpriteSequences[i].Loop,
					sprites);
				frameSequence.DestReached += FrameSequence_DestReached;
				frameSequence.SequenceFinished += (name) =>
				{
					SequenceFinished?.Invoke(name);
				};
				sequences.Add(animatedSpriteInfos.AnimatedSpriteSequences[i].Name, frameSequence);
			}

			currentSequence = sequences.ElementAt(0).Value;
			currentSequence.SequenceFinished += (name) =>
			{
				SequenceFinished?.Invoke(name);
			};
		}

		private void FrameSequence_DestReached()
		{
			DestReached?.Invoke(this);
		}

		public void ChangeSequence(string seqName)
        {
			var newAnimSequence = sequences[seqName];
			newAnimSequence.Position = currentSequence.Position;
			currentSequence = newAnimSequence;
		}

		public void ChangeToSpecificFrame(string seqName, int index)
		{
			var newAnimSequence = sequences[seqName];
			newAnimSequence.Position = currentSequence.Position;
			currentSequence = newAnimSequence;
			newAnimSequence.ChangeToSpecificFrame(index);
		}

		public void Resume()
		{
			currentSequence.Resume();
		}

		public void SetSteering(SpriteMovement movement)
        {
			this.movement = movement;
			currentSequence.SetSteering(movement);
		}

        public override void Render(Graphics g, IRenderer renderer)
		{
			currentSequence.Render(g, renderer);
		}
	}

	public class AnimatedSpriteSequence
	{
		private AnimatedSpriteTimer timer;
		private string name;
		private float time;
		private List<Sprite> sprites;
		private Sprite currentSprite;
		private int curRenderSpriteIndex = 0;
		private bool loop;

		private PointF position;
		private float initDelayTime = 0.1f;
		private float curDelayTime = 0;

		public string Name { get { return name; } }
		public float Time { get { return time; } }
		public List<Sprite> Sprites { get { return sprites; } }
		public PointF Position
		{
            get { return currentSprite.Position; }
            set 
			{ 
				foreach(Sprite sprite in sprites)
				{
					sprite.Position = value;
				}
			}
		}
		public SizeF Size
		{
			get { return currentSprite.Size; }
			set
			{
				foreach (Sprite sprite in sprites)
				{
					sprite.Size = value;
				}
			}
		}

		public event Action DestReached;
		public event Action<string> SequenceFinished;

		public AnimatedSpriteSequence(
			string name, 
			float time,
			bool loop,
			List<Sprite> sprites)
		{
			this.name = name;
			this.time = time;
			this.sprites = sprites;
			currentSprite = sprites[0];
			foreach(Sprite sprite in sprites)
			{
				sprite.DestReached += SpriteCheckDestReached;
			}
			position = currentSprite.Position;
			
			this.loop = loop;

			timer = new AnimatedSpriteTimer(5, 1);
			timer.Tick += Timer_Tick;
			timer.Start();
		}

		private void Timer_Tick()
		{
			if (curRenderSpriteIndex == sprites.Count - 1)
			{
				if (loop) { curRenderSpriteIndex = 0; }
				else { SequenceFinished?.Invoke(name); }
			}
			else
			{
				curRenderSpriteIndex++;//Move to next sprite image
			}
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
			timer.Update();

			//Animation Control Systems
			currentSprite = sprites[curRenderSpriteIndex];
			currentSprite.Render(g, renderer);
		}

		private void SpriteCheckDestReached()
		{
			DestReached?.Invoke();
		}

		public void ChangeToSpecificFrame(int index)
		{
			curRenderSpriteIndex = index;
			timer.Deactive();
		}

		public void Resume()
		{
			timer.Start();
		}
	}
}
