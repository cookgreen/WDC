using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WDC.Xml;

namespace WDC.Game
{
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
