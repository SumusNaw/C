using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Crawler.Model
{
    [XmlRoot("Configuration")]
    public class GlobalConfiguration
    {
        [XmlElement("StartPage")]
        public string StartPage { get; set; }

        [XmlElement("StartParam")]
        public string StarParameter { get; set; }

        [XmlElement("ReguestParameters")]
        public RequestParameters RequestParameters { get; set; }
        
        [XmlElement("Limitation")]
        public Limitation Limitation { get; set; }

        [XmlElement("OutputDirectory")]
        public string OutputDirectory { get; set; }
    }

    public class Limitation
    {
        [XmlElement("MaxConcurentRequest")]
        public int MaxConcurentRequest { get; set; }
        
        [XmlElement("MaxRequestPerMinute")]
        public int MaxRequestPerMinute { get; set; }
    }

    public class RequestParameters
    {
        [XmlElement("Accept")]
        public string Accept { get; set; }

        [XmlElement("Accept-Encoding")]
        public string AcceptEncoding { get; set; }

        [XmlElement("Accept-Language")]
        public string AcceptLanguage { get; set; }

        [XmlElement("Connection")]
        public string Connection { get; set; }

        [XmlElement("Host")]
        public string Host { get; set; }

        [XmlElement("User-Agent")]
        public string UserAgent { get; set; }
    }
}
