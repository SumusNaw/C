using System.IO;
using System.Net;
using System.Text;
using Crawler.Model;
using HtmlAgilityPack;

namespace Crawler
{
    class HtmlPage
    {
        private string _UrlAddress { get; }
        private string _Content { get; set; }
        private PageSettings _Config { get; }

        public HtmlPage(string urlAddress, PageSettings pageSettings)
        {
            _UrlAddress = urlAddress;
            _Config = pageSettings;
        }

        public string Content
        {
            get
            {
                if (string.IsNullOrEmpty(_Content))
                {
                    GetContent();
                }
                return _Content;
            }
        }

        private void GetContent()
        {
            HttpWebRequest request = CreateRequest();
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    using (Stream receiveStream = response.GetResponseStream())
                    {
                        StreamReader readStream = null;

                        if (response.CharacterSet == null)
                        {
                            readStream = new StreamReader(receiveStream);
                        }
                        else
                        {
                            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        }

                        _Content = readStream.ReadToEnd();

                        response.Close();
                        readStream.Close();
                    }
                }
            }
        }

        private HttpWebRequest CreateRequest()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_UrlAddress);
            request.UserAgent = _Config.RequestParameters.UserAgent;
            request.Accept = _Config.RequestParameters.Accept;
            request.KeepAlive = _Config.RequestParameters.Connection.Equals("keep-alive");
            request.Host = _Config.RequestParameters.Host;

            return request;
        }

        public HtmlDocument GetPage()
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(Content);

            return doc;
        }
    }
}
