using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GarbageClassificationScript.Localization
{
	[XmlRoot("LocalizedStrings")]
	public class LocalizedStrings
	{
		[XmlElement("LocalizedString")]
		public List<LocalizedString> localizedStrings { get; set; }

		public LocalizedStrings()
		{
			localizedStrings = new List<LocalizedString>();
		}

		public static LocalizedStrings LoadXml(string xmlFile)
		{
			if(File.Exists(xmlFile))
			{
				using (StreamReader sr = File.OpenText(xmlFile))
				{
					XmlSerializer serializer = new XmlSerializer(typeof(LocalizedStrings));
					LocalizedStrings xmlObject = serializer.Deserialize(sr) as LocalizedStrings;
					return xmlObject;
				}
			}
			return null;
		}
	}

	[XmlRoot("LocalizedString")]
	public class LocalizedString
	{
		[XmlAttribute("id")]
		public string ID { get; set; }

		[XmlElement("LocalizedStringEntry")]
		public List<LocalizedStringEntry> Entries { get; set; }

		public LocalizedString() 
		{
			Entries = new List<LocalizedStringEntry>();
		}
	}

	[XmlRoot("LocalizedStringEntry")]
	public class LocalizedStringEntry
	{
		[XmlAttribute("lang")]
		public string LangName { get; set; }

		[XmlText]
		public string Value { get; set; }
	}

	public class localizedStringsLoader
	{
		private string xmlFile;
		private LocalizedStrings LocalizedStrings;

		public localizedStringsLoader(string xmlFile)
		{
			this.xmlFile = xmlFile;
			LocalizedStrings = LocalizedStrings.LoadXml(xmlFile);
		}

		public string FindText(string id, string langName)
		{
			return LocalizedStrings.localizedStrings.Where(o=>o.ID == id).FirstOrDefault().
				Entries.Where(o=>o.LangName==langName).FirstOrDefault().Value;
		}
	}
}
