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

            PageSettings config = Configuration.Read(args[0]);

            HtmlPage htmlPage = new HtmlPage(config.StartPage, config);
            var doc = htmlPage.GetPage();


            var w = new work(config);

            Console.ReadKey();
        }
    }
}
