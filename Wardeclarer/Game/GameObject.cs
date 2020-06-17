﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardeclarer.Game
{
	public enum LayerDetectedState
	{
		None,
		Enter,
		Leave,
	}

	public class GameObject
	{
		private string uniqueID;
		protected LayerDetectedState state;
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
			state = LayerDetectedState.None;
		}

		public bool CheckEnterArea(int x, int y)
		{
			if (area == null)
			{
				return false;
			}
			return x > area.X && x < area.X + area.Width && y > area.Y && y < area.Y + area.Height;
		}

		public virtual void Update(Graphics g)
		{
			
		}

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
