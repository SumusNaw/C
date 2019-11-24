using System;
using Crawler.Model;

namespace Crawler
{
    public class work
    {
        readonly PageSettings _config;
        public work(PageSettings config)
        {
            _config = config;
        }

        public void start()
        {
            HtmlPage htmlPage = new HtmlPage(_config.StartPage, _config);
            Console.WriteLine(htmlPage.Content);
        }
    }
}
