using System.Collections.Generic;
using HtmlAgilityPack;

namespace Crawler
{
    class PageHelper
    {
        public IEnumerable<string> GetNextPages(HtmlDocument doc, IEnumerable<string> nextNodes)
        {
            IList<string> n = new List<string>();

            foreach (var x in nextNodes)
            {
                var m = doc.DocumentNode.SelectNodes(x);
            }

            return n;

        }
    }
}
