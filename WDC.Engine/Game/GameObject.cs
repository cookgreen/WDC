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
		protected string uniqueID;
		protected Point mousePosition;
		protected string typeName;
		protected LayerDetectedState state;
		protected PointF position;
		protected SizeF size;
		protected RectangleF area;

		public event Action<GameObject> MouseClicked;

		public object Tag 
		{ 
			get; 
			set; 
		}

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

		public RectangleF Rectangle
		{
			get { return new RectangleF(position, size); }
		}


		public GameObject(string typeName)
		{
			this.typeName = typeName;
			uniqueID = string.Format("{0}-{1}", typeName, Guid.NewGuid().ToString());
			state = LayerDetectedState.None;
		}

		public virtual bool CheckEnterArea(int x, int y, Engine engine)
		{
			mousePosition = new Point(x, y);

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
			MouseClicked?.Invoke(this);
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
