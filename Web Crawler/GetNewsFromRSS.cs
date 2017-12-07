using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebCrawler.src;

namespace WebCrawler
{
    public class GetNewsFromRSS
    {
        private string[] rssLink;
        private List<News> NL;
        public GetNewsFromRSS()
        {
            rssLink = new string[1];
            rssLink[0] = "http://www.tempo.co/rss/terkini";

            RSSParser RP = new RSSParser(rssLink);
            NL = RP.getNews();
        }

        public List<News> GetListNews()
        {
            return NL;
        }
        
        public string getRSSLink()
        {
            return rssLink[0];
        }
    }
}