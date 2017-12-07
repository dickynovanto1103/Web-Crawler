using System;

namespace WebCrawler {
    public class BoyerMoore : Searcher {
        private int[] last_occurence;

        public BoyerMoore(string keyword) : base(keyword) {
            pattern = keyword.ToLower();
            last_occurence = new int[pattern.Length];
            last_occurence = CreateLastOccurence();
        }

        public int[] CreateLastOccurence() {
            int[] res = new int[128];
            for (int i = 0; i < 128; i++) {
                res[i] = -1;
            }
            for (int i = 0; i < pattern.Length; i++) {
                res[pattern[i]] = i;
            }
            return res;
        }

        public override int searchIn(string text) {
            string lower_case_text = text.ToLower();
            int text_length = text.Length;
            int pattern_length = pattern.Length;
            int text_idx = pattern_length - 1;

            if (text_idx > text_length - 1) {
                return -1;
            }

            int pattern_idx = pattern.Length - 1;
            do {
                if (pattern[pattern_idx] == lower_case_text[text_idx]) {
                    if (pattern_idx == 0) {
                        return text_idx;
                    }
                    else {
                        text_idx--;
                        pattern_idx--;
                    }
                }
                else {
                    int last_occured = last_occurence[lower_case_text[text_idx]];
                    text_idx = text_idx + pattern_length - Math.Min(pattern_idx, last_occured + 1);
                    pattern_idx = pattern_length - 1;
                }
            } while (text_idx <= text_length - 1);

            return -1;
        }
    }
}
