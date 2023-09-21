using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace DefendCastleScript.Xml
{
	[XmlRoot("Game")]
	public class GameXml
	{
		[XmlElement]
		public GameXmlFileSection BoostMap { get; set; }

		[XmlElement]
		public GameXmlFileSection Art { get; set; }

		[XmlElement]
		public GameXmlDataSet DataSet { get; set; }

		[XmlElement]
		public GameLevelList Levels { get; set; }

		public GameLevel this[int levelNo]
		{
			get
			{
				return Levels.Level.Where(o => o.No == levelNo).FirstOrDefault();
			}
		}
		public GameXmlData this[string keyName]
		{
			get
			{
				return DataSet.Data.Where(o => o.Name == keyName).FirstOrDefault();
			}
		}

		public GameXml()
		{
			Art = new GameXmlFileSection();
			DataSet = new GameXmlDataSet();
			Levels = new GameLevelList();
		}

		public static GameXml Parse(string xmlfile)
		{
			var stream = File.OpenRead(xmlfile);
			XmlSerializer serializer = new XmlSerializer(typeof(GameXml));
			GameXml gameXml = serializer.Deserialize(stream) as GameXml;
			stream.Close();

			return gameXml;
		}
	}

	[XmlRoot]
	public class GameXmlFileSection
	{
		[XmlAttribute]
		public string file { get; set; }
	}

	[XmlRoot("DataSet")]
	public class GameXmlDataSet
	{
		[XmlElement]
		public List<GameXmlData> Data { get; set; }
	}

	[XmlRoot("Data")]
	public class GameXmlData
	{
		[XmlAttribute]
		public string Name { get; set; }

		[XmlElement]
		public List<GameXmlDataPair> DataPair { get; set; }

		public Dictionary<string, string> ToDic()
		{
			Dictionary<string, string> dic = new Dictionary<string, string>();
			foreach(var pair in DataPair)
			{
				dic[pair.Name] = pair.Value;
			}
			return dic;
		}
	}

	[XmlRoot("DataPair")]
	public class GameXmlDataPair
	{
		[XmlAttribute]
		public string Name { get; set; }

		[XmlText]
		public string Value { get; set; }
	}

	[XmlRoot("LevelData")]
	public class GameLevelData
	{
		[XmlAttribute]
		public string Name { get; set; }

		[XmlAttribute]
		public string Value { get; set; }
	}

	[XmlRoot("Level")]
	public class GameLevel
	{
		[XmlAttribute]
		public int No { get; set; }

		[XmlElement]
		public List<GameLevelData> LevelData { get; set; }

		public GameLevel()
		{
			LevelData = new List<GameLevelData>();
		}
	}

	[XmlRoot("Levels")]
	public class GameLevelList
	{
		[XmlElement]
		public List<GameLevel> Level { get; set; }

		public GameLevelList()
		{
			Level = new List<GameLevel>();
		}
	}
}
