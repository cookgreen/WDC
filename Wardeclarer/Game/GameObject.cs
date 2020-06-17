using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Game
{
	public class GameObject
	{
		private string uniqueID;
		protected PointF position;
		protected RectangleF area;
		public event Action MouseClicked;
		public string UID
		{
			get { return uniqueID; }
		}
		public PointF Position
		{
			get { return position; }
			set { position = value; }
		}

		public GameObject()
		{
			uniqueID = Guid.NewGuid().ToString();
		}

		public bool CheckEnterArea(int x, int y)
		{
			if (area == null)
			{
				return false;
			}
			return x > Position.X && x < Position.X + area.Width && y > Position.Y && y < Position.Y + area.Height;
		}

		public virtual void Update(Graphics g)
		{
		}

		public void Click()
		{
			MouseClicked?.Invoke();
		}
	}
}
