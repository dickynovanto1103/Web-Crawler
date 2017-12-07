using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCrawler
{
    public partial class _Default : Page
    {
        RSSParser RP;
        List<News> NL;
        int index;
        protected void Page_Load(object sender, EventArgs e) {
            //loading berita
            string[] rssLink;
            rssLink = new string[1];
            rssLink[0] = "http://www.tempo.co/rss/terkini";

            //parsing rss dan mendapatkan list of News
            RP = new RSSParser(rssLink);
            NL = RP.getNews();

            //inisialisasi
            contentHasilPencarian.Text = string.Empty;
        }

        protected void ButtonClick(object sender, EventArgs e) {
            contentHasilPencarian.Text = "<hr>";
            //baca pilihan dari buttonlist
            if ((SearchInput.Text == string.Empty) || (AlgoSelection.SelectedItem == null)) {
                if (SearchInput.Text == string.Empty) {
                    contentHasilPencarian.Text += "Could not process empty string.";
                }
                if (AlgoSelection.SelectedItem == null) {
                    contentHasilPencarian.Text += "<br>No algorithm selected.";
                }
            }
            else {
                string kalimat = "";

                foreach (News N in NL) {
                    GetterKalimat get = new GetterKalimat(N.getContent());
                    Searcher algo;
                    //Console.WriteLine("berita: "+N.getContent());
                    if (AlgoSelection.SelectedItem.Text == "KMP") {
                        algo = new KMP(SearchInput.Text);
                    }
                    else if (AlgoSelection.SelectedItem.Text == "Boyer-Moore") {
                        algo = new BoyerMoore(SearchInput.Text);
                    }
                    else {
                        algo = new RegEx(SearchInput.Text);
                    }
                    //menampilkan indeks dari konten yang dicari
                    //mencari di judul
                    index = algo.searchIn(N.getTitle());
                    if (index > 0) {
                        GetterKalimat getInJudul = new GetterKalimat(N.getTitle());
                        string url = "<a href=" + N.getUrl() + ">" + N.getTitle() + "</a>";
                        kalimat = N.getTitle();
                        contentHasilPencarian.Text += url + "<br><br>" + kalimat + "<br><br><hr>";
                    }
                    else {
                        //mencari di konten berita
                        index = algo.searchIn(N.getContent());
                        if (index > 0) {
                            string url = "<a href=" + N.getUrl() + ">" + N.getTitle() + "</a>";
                            kalimat = get.getKalimat(index);
                            contentHasilPencarian.Text += url + "<br><br>" + kalimat + "<br><br><hr>";
                        }
                    }
                }
            }
        }

        public void AboutClick(object sender, EventArgs e) {
            Response.Redirect("About.aspx");
        }
    }
}