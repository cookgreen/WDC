using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WDC.Core;

namespace WDC.Game
{
	public enum LayerDetectedState
	{
		None,
		Enter,
		Leave,
	}

	public class GameObject : IRenderable
	{
		private string uniqueID;
		protected string typeName;
		protected LayerDetectedState state;
		protected PointF position;
		protected SizeF size;
		protected RectangleF area;
		public event Action MouseClicked;
		public string UID
		{
			get { return uniqueID; }
		}
		public virtual PointF Position
		{
			get { return position; }
			set { position = value; }
		}

		public virtual SizeF Size
		{
			get { return size; }
			set { size = value; }
		}


		public GameObject(string typeName)
		{
			this.typeName = typeName;
			uniqueID = Guid.NewGuid().ToString();
			state = LayerDetectedState.None;
		}

		public bool CheckEnterArea(int x, int y, Engine engine)
		{
			if (!isValidArea(area))
			{
				return false;
			}
			return x > engine.Renderer.RenderOffset + area.X && x < engine.Renderer.RenderOffset + area.X + area.Width && y > area.Y && y < area.Y + area.Height;
		}

        private bool isValidArea(RectangleF area)
        {
			return area.Width > 0 & area.Height > 0;
        }

        public virtual void Render(Graphics g, IRenderer renderer)
		{
			
		}

        public Engine engine { get; set; }

		public void Click()
		{
			MouseClicked?.Invoke();
		}

		public virtual void Enter()
		{
			state = LayerDetectedState.Enter;
		}

		public virtual void Leave()
		{
			state = LayerDetectedState.Leave;
		}
	}
}
