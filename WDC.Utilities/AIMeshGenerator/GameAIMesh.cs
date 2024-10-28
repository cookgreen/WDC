using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AIMeshGenerator
{

    [XmlRoot("AIMesh")]
    public class GameAIMesh
    {
        [XmlElement("AIMeshBlock")]
        public List<GameAIMeshBlock> AIMeshList { get; set; }

        public GameAIMesh() 
        {
            AIMeshList = new List<GameAIMeshBlock>();
        }

        public void Save(string file)
        {
            if (File.Exists(file)) File.Delete(file);

            var stream = File.OpenWrite(file);
            XmlSerializer serializer = new XmlSerializer(typeof(GameAIMesh));
            serializer.Serialize(stream, this);
            stream.Close();
        }
    }

    [XmlRoot("AIMeshBlock")]
    public class GameAIMeshBlock
    {
        [XmlAttribute]
        public string size { get; set; }
        [XmlAttribute]
        public string location { get; set; }
    }
}
