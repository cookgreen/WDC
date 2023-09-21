using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DefendCastleScript.Xml
{
	public enum GameMapAIMeshType
	{
		Asset, //Use a image as the ai mesh defination
		Defination //Use the coord as the ai mesh defination
	}

	[XmlRoot("Map")]
	public class GameMapXml
	{
		[XmlAttribute("art")]
		public string Art { get; set; }

		[XmlAttribute("aimesh")]
		public string AIMesh { get; set; }

		[XmlAttribute("aimesh_type")]
		public GameMapAIMeshType AIMeshType { get; set; }
	}
}
