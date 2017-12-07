using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebCrawler {
    public class HTMLParser {
        string news_content;

        public HTMLParser(string url) {
            /*
            HtmlDocument htmlDoc = new HtmlDocument();
            HtmlAgilityPack.HtmlNode.ElementsFlags["br"] = HtmlAgilityPack.HtmlElementFlag.Empty;
            htmlDoc.OptionWriteEmptyNodes = true;

            HttpClient http = new HttpClient();
            var response = http.GetByteArrayAsync(url);
            string content = Encoding.GetEncoding("utf-8").GetString(response);
            htmlDoc.LoadHtml(content);

            var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//p");
            foreach (var node in htmlNodes)
            {
                Console.WriteLine(node.OuterHtml);
                news_content = node.OuterHtml;
            }
            */

            HtmlDocument htmlDoc = new HtmlDocument();
            string html = new HttpClient().GetStringAsync(url).Result;
            htmlDoc.LoadHtml(html);

            var nodes = htmlDoc.DocumentNode.SelectNodes("//p");
            //foreach (var node in nodes)
            //{
            //Console.WriteLine(nodes[0].OuterHtml);
            news_content = nodes[0].InnerText;
            //}
        }

        public string getContent() {
            return news_content;
        }
    }
}
