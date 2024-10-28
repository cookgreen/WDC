using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WDC.Xml
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

        [XmlElement]
        public GameMapInfo MapInfo { get; set; }

        public static GameMapXml Parse(string xmlfile)
        {
            var stream = File.OpenRead(xmlfile);
            XmlSerializer serializer = new XmlSerializer(typeof(GameMapXml));
            GameMapXml gameMapXml = serializer.Deserialize(stream) as GameMapXml;
            stream.Close();

            return gameMapXml;
        }

        public void Save(string file)
        {
            if (File.Exists(file)) File.Delete(file);

            var stream = File.OpenWrite(file);
            XmlSerializer serializer = new XmlSerializer(typeof(GameMapXml));
            serializer.Serialize(stream, this);
            stream.Close();
        }
    }

    [XmlRoot("MapInfo")]
    public class GameMapInfo
    {
        [XmlElement("AIMesh")]
        public GameMapAIMesh AIMesh { get; set; }
    }

    [XmlRoot("AIMesh")]
    public class GameMapAIMesh
    {
        [XmlElement("AIMeshBlock")]
        public List<GameMapAIMeshBlock> AIMeshList { get; set; }

        public void Save(string file)
        {
            if (File.Exists(file)) File.Delete(file);

            var stream = File.OpenWrite(file);
            XmlSerializer serializer = new XmlSerializer(typeof(GameMapAIMesh));
            serializer.Serialize(stream, this);
            stream.Close();
        }
    }

    [XmlRoot("AIMeshBlock")]
    public class GameMapAIMeshBlock : IComparable<GameMapAIMeshBlock>
    {
        private Size size;
        private Point wpos;
        private Point cpos;

        [XmlAttribute("size")]
        public string SizeStr { get; set; }
        [XmlAttribute("location")]
        public string Location { get; set; }

        [XmlIgnore]
        public Point WPos
        {
            get
            {
                string[] tokens = Location.Split(',');
                wpos = new Point(int.Parse(tokens[0].Trim()), int.Parse(tokens[1].Trim()));
                return wpos;
            }
        }

        [XmlIgnore]
        public Point CPos
        {
            get
            {
                string[] tokens = Location.Split(',');
                string[] tokens2 = SizeStr.Split(',');
                int width = int.Parse(tokens2[0].Trim());
                int height = int.Parse(tokens2[1].Trim());
                cpos = new Point(int.Parse(tokens[0].Trim()) + width / 2, int.Parse(tokens[1].Trim()) + height / 2);
                return cpos;
            }
        }

        [XmlIgnore]
        public Size Size
        {
            get
            {
                string[] tokens2 = SizeStr.Split(',');
                int width = int.Parse(tokens2[0].Trim());
                int height = int.Parse(tokens2[1].Trim());
                size = new Size(width, height);
                return size;
            }
        }

        [XmlIgnore]
        public int CostF { get; set; }
        [XmlIgnore]
        public int CostG { get; set; }
        [XmlIgnore]
        public int CostH { get; set; }
        [XmlIgnore]
        public GameMapAIMeshBlock LastNode { get; set; }
        [XmlIgnore]
        public bool IsWall { get; set; }

        public List<GameMapAIMeshBlock> GetNearbyBlocks(List<GameMapAIMeshBlock> blocks)
        {
            List<GameMapAIMeshBlock> nearbyBlocks = new List<GameMapAIMeshBlock>();

            string loc = string.Format("{0}, {1}", WPos.X, WPos.Y - Size.Height);
            var result = blocks.Where(o => o.Location == loc);
            if (result.Count() > 0)
            {
                nearbyBlocks.Add(result.First());
            }

            loc = string.Format("{0}, {1}", WPos.X, WPos.Y + Size.Height);
            result = blocks.Where(o => o.Location == loc);
            if (result.Count() > 0)
            {
                nearbyBlocks.Add(result.First());
            }

            loc = string.Format("{0}, {1}", WPos.X - Size.Width, WPos.Y);
            result = blocks.Where(o => o.Location == loc);
            if (result.Count() > 0)
            {
                nearbyBlocks.Add(result.First());
            }

            loc = string.Format("{0}, {1}", WPos.X + Size.Width, WPos.Y);
            result = blocks.Where(o => o.Location == loc);
            if (result.Count() > 0)
            {
                nearbyBlocks.Add(result.First());
            }

            return nearbyBlocks;
        }

        public bool ContainsLoc(Point pos)
        {
            Rectangle rect = new Rectangle(WPos, Size);
            return rect.Contains(pos);
        }

        public bool ContainsLocF(PointF pos)
        {
            RectangleF rect = new RectangleF(WPos, Size);
            return rect.Contains(pos);
        }

        public int CompareTo(GameMapAIMeshBlock other)
        {
            if (SizeStr == other.SizeStr && Location == other.Location)
                return 0;
            else
                return 1;
        }
    }
}
