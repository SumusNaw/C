using Crawler.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crawler
{
    public class Crawler
    {
        Pages Pages;
        GlobalConfiguration Config;
        CategoryPageConfiguration CategoryConfig;
        ProductPageConfiguration ProductConfig;

        public Crawler(Pages pages, GlobalConfiguration config, CategoryPageConfiguration categoryConfig, ProductPageConfiguration productConfig)
        {
            Pages = pages;
            Config = config;
            CategoryConfig = categoryConfig;
            ProductConfig = productConfig;
        }

        public void Start()
        {

        }

        public void W()
        {
            Page page = Pages.GetNextPage();
            HtmlPage.DownloadPageContent(page, Config.RequestParameters);


        }
    }
}
