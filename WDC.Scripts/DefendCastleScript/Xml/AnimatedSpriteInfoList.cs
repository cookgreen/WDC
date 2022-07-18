using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace DefendCastleScript.Xml
{
    [XmlRoot]
    public class AnimatedSpriteInfoList
    {
        [XmlElement("AnimatedSpriteInfo")]
        public List<AnimatedSpriteInfo> AnimatedSprites { get; set; }

        public AnimatedSpriteInfoList()
        {
            AnimatedSprites = new List<AnimatedSpriteInfo>();
        }

        public static AnimatedSpriteInfoList Parse(string animatedSpriteInfoListXml)
        {
            FileStream fileStream = new FileStream(animatedSpriteInfoListXml, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(AnimatedSpriteInfoList));
            AnimatedSpriteInfoList ast = serializer.Deserialize(fileStream) as AnimatedSpriteInfoList;
            fileStream.Close();
            return ast;
        }
    }

    [XmlRoot]
    public class AnimatedSpriteInfo
    {
        [XmlArray("AnimatedSpriteSequences")]
        [XmlArrayItem("AnimatedSpriteSequence")]
        public List<AnimatedSpriteSequence> AnimatedSpriteSequences { get; set; }
        
        public AnimatedSpriteInfo()
        {
            AnimatedSpriteSequences = new List<AnimatedSpriteSequence>();
        }
    }

    [XmlRoot]
    public class AnimatedSpriteSequence
    {
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public int Start { get; set; }

        [XmlAttribute]
        public int Length { get; set; }

        [XmlElement("AnimatedSpriteSequenceRegion")]
        public List<AnimatedSpriteSequenceRegion> Regions { get; set; }

        public AnimatedSpriteSequence()
        {
            Regions = new List<AnimatedSpriteSequenceRegion>();
        }
    }

    [XmlRoot]
    public class AnimatedSpriteSequenceRegion
    {
        [XmlAttribute]
        public int Width { get; set; }

        [XmlAttribute]
        public int Height { get; set; }

        [XmlAttribute]
        public int OffsetX { get; set; }

        [XmlAttribute]
        public int OffsetY { get; set; }
    }
}