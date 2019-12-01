using System;
using System.Collections.Generic;
using System.Text;

namespace Crawler.Model
{
    public class Page
    {
        public string Url { get; set; }
        public bool ProductPage { get; set; } = false;
        public bool CategoryPage { get; set; } = false;
        public string Content { get; set; }

        public Page(string url)
        {
            Url = url;
        }
    }
}
