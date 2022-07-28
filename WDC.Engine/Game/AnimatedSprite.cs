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

		public Action<string> SequenceFinished;

		public AnimatedSprite(
			Bitmap allFramesBitmap, 
			AnimatedSpriteInfo animatedSpriteInfos, 
			PointF position)
		{
			this.position = position;

			sequences = new Dictionary<string, AnimatedSpriteSequence>();
			timer = new AnimatedSpriteTimer();

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

					Sprite sprite = new Sprite(newImage, position);
					sprites.Add(sprite);
				}

				AnimatedSpriteSequence frameSequence = new AnimatedSpriteSequence(
					animatedSpriteInfos.AnimatedSpriteSequences[i].Name,
					animatedSpriteInfos.AnimatedSpriteSequences[i].Length, 
					sprites);
				sequences.Add(animatedSpriteInfos.AnimatedSpriteSequences[i].Name, frameSequence);
			}

			currentSequence = sequences.ElementAt(0).Value;
			currentSequence.SequenceFinished += (name) =>
			{
				SequenceFinished?.Invoke(name);
			};
		}

		public void ChangeSequence(string seqName)
        {
			currentSequence = sequences[seqName];
			currentSequence.SequenceFinished += (name) =>
			{
				SequenceFinished?.Invoke(name);
			};
		}

		public void SetSteering(SpriteMovement movement)
        {
			this.movement = movement;
			currentSequence.SetSteering(movement);

		}

        public override PointF Position
        {
            get { return position; }
            set
            {
				foreach(var seq in sequences)
                {
					seq.Value.Position = value;
                }
            }
		}

        public override void Render(Graphics g, IRenderer renderer)
		{
			currentSequence.Render(g, renderer);

			timer.Update();
		}
	}

	public class AnimatedSpriteSequence
	{
		private string name;
		private float time;
		private List<Sprite> sprites;

		private Sprite currentSprite;
		private PointF position;
		private bool hasBeenSet;
		private int curInternalTime = 0;
		private float initDelayTime = 0.1f;
		private float curDelayTime = 0;

		public string Name { get { return name; } }
		public float Time { get { return time; } }
		public List<Sprite> Sprites { get { return sprites; } }
		public PointF Position
		{
            get { return currentSprite.Position; }
            set { currentSprite.Position = value; }
        }

		public event Action<string> SequenceFinished;

		public AnimatedSpriteSequence(
			string name, 
			float time, 
			List<Sprite> sprites)
		{
			this.name = name;
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
			//Animation Control Systems
			currentSprite = sprites[curInternalTime];

			currentSprite.Render(g, renderer);

			if (curInternalTime == sprites.Count - 1)
			{
				curInternalTime = 0;
			}
			else
			{
				curInternalTime++;
			}
		}
	}
}
