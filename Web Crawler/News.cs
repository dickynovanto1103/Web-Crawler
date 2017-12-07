namespace WebCrawler {
    public class News {
        private string title;
        private string img_url;
        private string description;
        private string url;
        private string content;

        public News(string _title, string _img_url, string _description, string _url, string _content) {
            title = _title;
            img_url = _img_url;
            description = _description;
            url = _url;
            content = _content;
        }

        public string getTitle() {
            return title;
        }

        public string getImgUrl() {
            return img_url;
        }

        public string getDescription() {
            return description;
        }

        public string getUrl() {
            return url;
        }

        public string getContent() {
            return content;
        }
    }
}
