using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Crawler.Model
{
    [XmlRoot("CategoryPageConfiguration")]
    public class CategoryPageConfiguration
    {
        [XmlArray("NextCategoryPages")]
        [XmlArrayItem("Page")]
        public List<string> NextCategoryPages { get; set; }

        [XmlArray("NextProductPages")]
        [XmlArrayItem("Page")]
        public List<string> NextProductPages { get; set; }

        [XmlArray("NextPages")]
        [XmlArrayItem("Page")]
        public List<string> NextPages { get; set; }

        [XmlArray("CategoryRegex")]
        [XmlArrayItem("Regex")]
        public List<string> CategoryRegex { get; set; }

        [XmlArray("ProductRegex")]
        [XmlArrayItem("Regex")]
        public List<string> ProductRegex { get; set; }
    }
}
