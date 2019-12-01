using System;
using System.Linq;
using Common;
using Crawler.Model;
using HtmlAgilityPack;

namespace Crawler
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            ILog logger = new MyLog();

            if (args.Length == 0)
            {
                Exception e = new ArgumentException("Params not foud");
                logger.Error(e.Message, e);
                return;
            }

            GlobalConfiguration config = Configuration.Read<GlobalConfiguration>(args[0], logger);
            CategoryPageConfiguration categoryConfig = Configuration.Read<CategoryPageConfiguration>(args[1], logger);

            Pages pages = new Pages(categoryConfig.NextCategoryRegex, categoryConfig.NextProductRegex, logger);

            Crawler crawler = new Crawler(pages, config, categoryConfig, new ProductPageConfiguration());

            Console.ReadKey();
        }
    }
}
