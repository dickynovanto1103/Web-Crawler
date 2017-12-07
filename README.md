# WebCrawler
A web crawler using C# and ASP.NET

## Credits
* [Dicky Novanto](https://github.com/dickynovanto1103)
* [Oktavianus Handika](https://github.com/handikao29)
* [Rionaldi Chandraseta](https://github.com/rionaldichandraseta)

## Description
The program is essentially a News Aggregator for [Tempo.co](https://www.tempo.co/). The RSSParser would work for other sites' RSS Feed, but unfortunately the HTMLParser is site-specific. Thus, the HTMLParser may not work for other websites.

The crawler has three string-matching algorithm for the matching process:
* BoyerMoore
* Knuth-Morris-Pratt
* Regular Expression (uses C# library)

We do not release any artifacts for this program. Open the project in Visual Studio and run it to get it to work.
