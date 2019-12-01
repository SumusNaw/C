using Common;
using Crawler.Model;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Crawler
{
    public class Pages
    {
        private readonly ILog Logger ;
        private readonly ConcurrentQueue<Page> _CategoryPages;
        private readonly ConcurrentQueue<Page> _ProductPages;
        private readonly HashSet<string> _AllHistoryPages;
        private readonly IEnumerable<Regex> _ProductRegex;
        private readonly IEnumerable<Regex> _CategoryRegex;
        public Pages(IEnumerable<string> categoryRegularExpresions, IEnumerable<string> productRegularExpresions, ILog logger)
        {
            _AllHistoryPages = new HashSet<string>();
            _CategoryPages = new ConcurrentQueue<Page>();
            _ProductPages = new ConcurrentQueue<Page>();

            _ProductRegex = InitialRegex(productRegularExpresions);
            _CategoryRegex = InitialRegex(categoryRegularExpresions);

            Logger = logger;
        }

        private IEnumerable<Regex> InitialRegex(IEnumerable<string> regularExpresions)
        {
            IList<Regex> regex = new List<Regex>();
            foreach(string regularExpresion in regularExpresions)
            {
                try
                {
                    regex.Add(new Regex(regularExpresion));
                }
                catch (Exception e)
                {
                    Logger.Error(e.Message, e);
                }
            }
            return regex;
        }

        public void AddPage(string url)
        {
            if (_AllHistoryPages.Add(url))
            {
                Page page = new Page(url);
                if (IsProductOrCategoryPage(page))
                {
                    if (page.ProductPage)
                    {
                        _ProductPages.Enqueue(page);
                    }
                    else
                    {
                        _CategoryPages.Enqueue(page);
                    }
                }
            }
        }

        private bool IsProductOrCategoryPage(Page page)
        {
            bool result = false;
            foreach(Regex regex in _ProductRegex)
            {
                if (regex.IsMatch(page.Url))
                {
                    page.ProductPage = true;
                    result = true;
                    break;
                }
            }

            foreach (Regex regex in _CategoryRegex)
            {
                if (regex.IsMatch(page.Url))
                {
                    page.CategoryPage = true;
                    result = true;
                    break;
                }
            }

            if(result==false && !_ProductRegex.Any() && !_CategoryRegex.Any())
            {
                page.ProductPage = true;
                page.CategoryPage = true;
                result = true;
            }

            return result;
        }

        public bool IsEmpty()
        {
            return _CategoryPages.IsEmpty && _ProductPages.IsEmpty;
        }

        public Page GetNextProductPage()
        {
            if (_ProductPages.TryDequeue(out Page page))
            {
                return page;
            }
            return null;
        }

        public Page GetNextCategoryPage()
        {
            if (_CategoryPages.TryDequeue(out Page page))
            {
                return page;
            }
            return null;
        }

        public Page GetNextPage()
        {
            return GetNextProductPage() ?? GetNextCategoryPage();
        }
    }
}
