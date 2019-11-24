using System.Collections.Generic;
using System.Xml.Serialization;

namespace Crawler.Model
{
    [XmlRoot("PageSettings")]
    public class PageSettings
    {
        [XmlElement("MainPage")]
        public string StartPage { get; set; }

        [XmlElement("StartParam")]
        public string StarParameter { get; set; }

        [XmlElement("ReguestParameters")]
        public RequestParameters RequestParameters { get; set; }

        [XmlArray("NextPages")]
        [XmlArrayItem("NextPage")]
        public List<string> NextPages { get; set; }
    }
}
