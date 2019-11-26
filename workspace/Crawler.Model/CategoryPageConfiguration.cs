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

        [XmlArray("NextCategoryRegex")]
        [XmlArrayItem("Regex")]
        public List<string> NextCategoryRegex { get; set; }

        [XmlArray("NextProductPage")]
        [XmlArrayItem("Page")]
        public List<string> NextProductPage { get; set; }

        [XmlArray("NextProductRegex")]
        [XmlArrayItem("Regex")]
        public List<string> NextProductRegex { get; set; }
    }
}
