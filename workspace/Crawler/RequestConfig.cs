using System.Collections.Generic;

namespace Crawler
{
    class RequestConfig
    {
        public string UserAgent
        {
            get;
        }

        public string Accept
        {
            get;
        }

        public string KeepAlive
        {
            get;
        }

        public string Host
        {
            get;
        }

        IEnumerable<string> _UserAgents;

    }
}
