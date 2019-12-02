using Crawler.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crawler
{
    public class Crawler
    {
        Pages Pages;
        private readonly GlobalConfiguration Config;
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
            W();
        }

        public void W()
        {
            PageHelper pageHelper = new PageHelper(Config.RequestParameters);
            while (!Pages.IsEmpty())
            {
                Page page = Pages.GetNextPage();
                pageHelper.DownloadPage(page);

                ProcedCategoryPage(page.htmlDocument);
            }
        }

        private void ProcedCategoryPage(HtmlDocument doc)
        {
            foreach(var nextPageXPath in CategoryConfig.NextCategoryPages)
            {
                var x = doc.DocumentNode.SelectNodes(nextPageXPath);
                foreach(var y in x)
                {
                    var h = y.GetAttributeValue("href", "");
                    Pages.AddPage(h);
                }
            }
        }
    }
}
