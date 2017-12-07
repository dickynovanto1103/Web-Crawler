using System;
using System.Text.RegularExpressions;

namespace WebCrawler {
    public class RegEx : Searcher {
        public RegEx(string keyword) : base(keyword) {

        }
        public override int searchIn(string text) {
            Match match = Regex.Match(text, @pattern, RegexOptions.IgnoreCase);
            if (match.Success) {
                int index = match.Index;
                return index;
            }
            else {
                return -1;
            }
        }
    }
}