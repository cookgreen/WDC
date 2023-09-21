using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WDC.Game
{
	public class GameMapAIMeshPoint
	{
		private int x;
		private int y;

		public int X { get { return x; } }
		public int Y { get { return y; } }

		public GameMapAIMeshPoint(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}

	public class GameMapAIMeshUnit
	{
		private GameMapAIMeshPoint leftUp;
		private GameMapAIMeshPoint leftDown;
		private GameMapAIMeshPoint rightUp;
		private GameMapAIMeshPoint rightDown;

		public GameMapAIMeshPoint LeftUp{ get { return leftUp; } }
		public GameMapAIMeshPoint LeftDown { get { return leftDown; } }
		public GameMapAIMeshPoint RightUp { get { return rightUp; } }
		public GameMapAIMeshPoint RightDown { get { return rightDown; } }

		public int Width { get { return Math.Abs(leftUp.X - rightUp.X); } }
		public int Height { get { return Math.Abs(LeftDown.X - RightDown.X); } }

		public GameMapAIMeshUnit(
			GameMapAIMeshPoint leftUp, 
			GameMapAIMeshPoint leftDown, 
			GameMapAIMeshPoint rightUp, 
			GameMapAIMeshPoint rightDown
		)
		{
			this.leftUp = leftUp;
			this.leftDown = leftDown;
			this.rightUp = rightUp;
			this.rightDown = rightDown;
		}
	}

	public class GameMapAIMesh
	{
		private GameMapAIMeshUnit cursor;
		private List<GameMapAIMeshUnit> meshUnits;
		public List<GameMapAIMeshUnit> MeshUnits { get { return meshUnits; } }

		public GameMapAIMesh(List<GameMapAIMeshUnit> meshUnits)
		{
			this.meshUnits = meshUnits;
		}

		public GameMapAIMeshUnit CurrentAIMeshUnit { get { return cursor; } }

		public GameMapAIMeshUnit NextAIMeshUnitX
		{
			get { return cursor; }
		}
		public GameMapAIMeshUnit NextAIMeshUnitY
		{
			get { return cursor; }
		}

		public void MoveToNextAIMeshUnitX()
		{
			cursor = NextAIMeshUnitX; 
		}

		public void MoveToNextAIMeshUnitY()
		{
			cursor = NextAIMeshUnitX;
		}

		public List<GameMapAIMeshUnit> GetAIMeshUnitsBetweenTwoPositions(GameMapAIMeshPoint point1, GameMapAIMeshPoint point2)
		{
			return new List<GameMapAIMeshUnit>();
		}
	}

	public class GameMap
	{
		private Image mapImage;
		private GameMapAIMesh aiMesh;

		public Image Image { get { return mapImage; } }
		public GameMapAIMesh AIMesh { get { return aiMesh; } }

		public GameMap(Image mapImage, GameMapAIMesh aiMesh) 
		{
			this.mapImage = mapImage;
			this.aiMesh = aiMesh;
		}
	}
}
