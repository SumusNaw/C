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
            W(1);
        }

        public void W(int taskNumber)
        {
            PageHelper pageHelper = new PageHelper(Config.RequestParameters);
            while (Pages.TryGetPage(out Page page))
            {
                Console.WriteLine($"[{taskNumber}]: Start proceed page {page.Url}.");
                pageHelper.DownloadPage(page);

                if (page.CategoryPage)
                {
                    ProcedCategoryPage(page.htmlDocument);
                }

                if (page.ProductPage)
                {
                    ProceedProductPage(page.htmlDocument);
                }
            }
        }

        private void ProcedCategoryPage(HtmlDocument doc)
        {
            foreach(var nextPageXPath in CategoryConfig.NextCategoryPages)
            {
                HtmlNodeCollection hrefNodes = doc.DocumentNode.SelectNodes(nextPageXPath);
                foreach(HtmlNode hrefNode in hrefNodes)
                {
                    string href = hrefNode.GetAttributeValue("href", "");
                    Pages.AddCategoryPage(href);
                }
            }

            foreach (var nextPageXPath in CategoryConfig.NextProductPages)
            {
                HtmlNodeCollection hrefNodes = doc.DocumentNode.SelectNodes(nextPageXPath);
                foreach (HtmlNode hrefNode in hrefNodes)
                {
                    string href = hrefNode.GetAttributeValue("href", "");
                    Pages.AddProductPage(href);
                }
            }

            foreach (var nextPageXPath in CategoryConfig.NextPages)
            {
                HtmlNodeCollection hrefNodes = doc.DocumentNode.SelectNodes(nextPageXPath);
                foreach (HtmlNode hrefNode in hrefNodes)
                {
                    string href = hrefNode.GetAttributeValue("href", "");
                    Pages.AddPage(href);
                }
            }
        }

        private void ProceedProductPage(HtmlDocument doc)
        {
            switch (ProductConfig.PageType)
            {
                case ProductPageTypes.Image:
                    ProceedImagePageType(doc);
                    break;
            }
        }

        private void ProceedImagePageType(HtmlDocument doc)
        {
            foreach (var imageXPath in ProductConfig.Images)
            {
                HtmlNodeCollection hrefNodes = doc.DocumentNode.SelectNodes(imageXPath);
                foreach (HtmlNode hrefNode in hrefNodes)
                {
                    string href = hrefNode.GetAttributeValue("src", "");
                    Console.WriteLine(href);
                }
            }
        }
    }
}
