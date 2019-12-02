using Crawler.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Crawler
{
    public class PageHelper
    {
        private readonly RequestParameters _RequestParameters;
        public PageHelper(RequestParameters requestParameters)
        {
            _RequestParameters = requestParameters;
        }

        public bool DownloadPage(Page page)
        {
            try
            {
                string content = DownloadPageContent(page.Url);
                page.htmlDocument = new HtmlDocument();
                page.htmlDocument.LoadHtml(content);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private string DownloadPageContent(string url)
        {
            HttpWebRequest request = CreateRequest(url);
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

                        return readStream.ReadToEnd();
                    }
                }
            }
            return null;
        }

        private HttpWebRequest CreateRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = _RequestParameters.UserAgent;
            request.Accept = _RequestParameters.Accept;
            request.KeepAlive = _RequestParameters.Connection.Equals("keep-alive");
            request.Host = _RequestParameters.Host;

            return request;
        }
    }
}
