using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Crawler.Model
{
    public enum ProductPageTypes
    {
        Unknow = 0,
        Image = 1,
    }
    public class ProductPageConfiguration
    {
        public ProductPageTypes PageType
        {
            get
            {
                return (ProductPageType.ToLower()) switch
                {
                    "image" => ProductPageTypes.Image,
                    _ => ProductPageTypes.Unknow,
                };
            }
        }

        [XmlElement("ProductPageType")]
        public string ProductPageType { private get; set; }

        [XmlArray("Images")]
        [XmlArrayItem("Image")]
        public List<string> Images { get; set; }
    }
}
