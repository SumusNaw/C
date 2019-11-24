using System.Xml.Serialization;

namespace Crawler.Model
{
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
