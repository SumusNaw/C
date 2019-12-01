using Crawler.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace Crawler
{
    public class HtmlPage
    {
        public static bool DownloadPageContent(Page page, RequestParameters requestParameters)
        {
            bool result = false;

            HttpWebRequest request = CreateRequest(page.Url, requestParameters);
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

                        page.Content = readStream.ReadToEnd();
                        result = true;

                        response.Close();
                        readStream.Close();
                    }
                }
            }

            return result;
        }


        private static HttpWebRequest CreateRequest(string url, RequestParameters requestParameters)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = requestParameters.UserAgent;
            request.Accept = requestParameters.Accept;
            request.KeepAlive = requestParameters.Connection.Equals("keep-alive");
            request.Host = requestParameters.Host;

            return request;
        }
    }
}
