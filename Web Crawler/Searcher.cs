namespace WebCrawler {
    public class Searcher {
        protected string pattern;

        public Searcher(string input) {
            pattern = input.ToLower();
        }

        public string getPattern() {
            return pattern;
        }

        public void setPattern(string input) {
            pattern = input.ToLower();
        }

        public virtual int searchIn(string text) {
            return -1;
        }
    }
}