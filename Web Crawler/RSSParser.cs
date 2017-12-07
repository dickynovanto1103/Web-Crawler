using System;
using System.Collections.Generic;
using System.Xml;

namespace WebCrawler {
    public class RSSParser {
        private List<News> NewsFeed = new List<News>();

        public RSSParser(string[] RSSLinks) {
            XmlDocument rssXmlDoc = new XmlDocument();
            for (int i = 0; i < RSSLinks.Length; i++) {
                rssXmlDoc.Load(RSSLinks[i]);
                XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");
                foreach (XmlNode rssNode in rssNodes) {
                    XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                    string title = rssSubNode != null ? rssSubNode.InnerText : "";

                    rssSubNode = rssNode.SelectSingleNode("image");
                    string img_url = rssSubNode != null ? rssSubNode.InnerText : "";

                    rssSubNode = rssNode.SelectSingleNode("description");
                    string description = rssSubNode != null ? rssSubNode.InnerText : "";

                    rssSubNode = rssNode.SelectSingleNode("url");
                    string url = rssSubNode != null ? rssSubNode.InnerText : "";

                    // TODO: Use HTML Parser to get content
                    HTMLParser hp = new HTMLParser(url);
                    string content = hp.getContent();

                    News rssNews = new News(title, img_url, description, url, content);
                    NewsFeed.Add(rssNews);
                }
            }
        }

        public List<News> getNews() {
            return NewsFeed;
        }
    }
}
