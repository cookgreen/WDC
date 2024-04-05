using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WDC.Localization;
using WDC.Script;

namespace WDC.Configure
{
	[XmlRoot("GameConfig")]
	public class GameConfig
	{
		[XmlIgnore]
		public WDCScript CurrentSelectedScript { get; set; }

		[XmlAttribute("locate")]
		public string CurrentSelectedLocate { get; set; }

        [XmlAttribute("resolution")]
        public string Resolution { get; set; }

		public static GameConfig Load(string xmlFile)
        {
            if (File.Exists(xmlFile))
            {
                using (StreamReader sr = File.OpenText(xmlFile))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(GameConfig));
                    GameConfig xmlObject = serializer.Deserialize(sr) as GameConfig;
                    return xmlObject;
                }
            }
            return null;
        }

        public void Save(string xmlFile)
        {
            if (File.Exists(xmlFile))
            {
                File.Delete(xmlFile);
                using (StreamWriter sw = File.CreateText(xmlFile))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(GameConfig));
                    serializer.Serialize(sw, this);
                }
            }
        }
	}
}
