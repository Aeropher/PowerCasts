using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PowerCasts
{
    class Podcast
    {
        public string Title { get; set; }       // <title>Cortex 69: Minimum Viable</title>
        public string Description { get; set; } // <description>Grey needs more storage space, Myke built a gaming PC (nice!), and they both talk about what they want to see at WWDC.</description>
        public string PublishDate { get; set; } // <pubDate>Tue, 22 May 2018 10:45:00 GMT</pubDate>
        public string Url { get; set; }         // <enclosure url = "https://www.podtrac.com/pts/redirect.mp3/traffic.libsyn.com/cortex/Cortex_069.mp3" length= "95001239" type= "audio/mp3" />
        public string Length { get; set; }      // <enclosure url = "https://www.podtrac.com/pts/redirect.mp3/traffic.libsyn.com/cortex/Cortex_069.mp3" length= "95001239" type= "audio/mp3" />
        public string Type { get; set; }        // <enclosure url = "https://www.podtrac.com/pts/redirect.mp3/traffic.libsyn.com/cortex/Cortex_069.mp3" length= "95001239" type= "audio/mp3" />
        public string Link { get; set; }        // <link>http://relay.fm/cortex/69</link>
        public string Guid { get; set; }        // <guid>http://relay.fm/cortex/69</guid>
        public string Author { get; set; }      // <itunes:author>CGP Grey and Myke Hurley</itunes:author>
        public string Subtitle { get; set; }    // <itunes:subtitle>Grey needs more storage space, Myke built a gaming PC (nice!), and they both talk about what they want to see at WWDC.</itunes:subtitle>
        public string Summary { get; set; }     // <itunes:summary>Grey needs more storage space, Myke built a gaming PC (nice!), and they both talk about what they want to see at WWDC.</itunes:summary>
        public string Explicit { get; set; }    // <itunes:explicit>clean</itunes:explicit>
        public string Duration { get; set; }    // <itunes:duration>5891</itunes:duration>
        public string Encoded { get; set; }     // <content:encoded>&lt;p&gt;Grey needs more storage space, Myke built a gaming PC (nice!), and they both talk about what they want to see at WWDC.&lt;/p&gt;</content:encoded>

        public Podcast(XElement ShowInfo)
        {
            Title       = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("title")).First().Value;                         // <title>Cortex 69: Minimum Viable</title>
            Description = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("description")).First().Value;                   // <description>Grey needs more storage space, Myke built a gaming PC (nice!), and they both talk about what they want to see at WWDC.</description>
            PublishDate = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("pubdate")).First().Value;                       // <pubDate>Tue, 22 May 2018 10:45:00 GMT</pubDate>
            Url         = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("enclosure")).First().Attribute("url").Value;    // <enclosure url = "https://www.podtrac.com/pts/redirect.mp3/traffic.libsyn.com/cortex/Cortex_069.mp3" length= "95001239" type= "audio/mp3" />
            Length      = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("enclosure")).First().Attribute("length").Value; // <enclosure url = "https://www.podtrac.com/pts/redirect.mp3/traffic.libsyn.com/cortex/Cortex_069.mp3" length= "95001239" type= "audio/mp3" />
            Type        = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("enclosure")).First().Attribute("type").Value;   // <enclosure url = "https://www.podtrac.com/pts/redirect.mp3/traffic.libsyn.com/cortex/Cortex_069.mp3" length= "95001239" type= "audio/mp3" />
            Link        = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("link")).First().Value;                          // <link>http://relay.fm/cortex/69</link>
            Guid        = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("guid")).First().Value;                          // <guid>http://relay.fm/cortex/69</guid>
            Author      = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("author")).First().Value;                        // <itunes:author>CGP Grey and Myke Hurley</itunes:author>
            Subtitle    = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("subtitle")).First().Value;                      // <itunes:subtitle>Grey needs more storage space, Myke built a gaming PC (nice!), and they both talk about what they want to see at WWDC.</itunes:subtitle>
            Summary     = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("summary")).First().Value;                       // <itunes:summary>Grey needs more storage space, Myke built a gaming PC (nice!), and they both talk about what they want to see at WWDC.</itunes:summary>
            Explicit    = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("explicit")).First().Value;                      // <itunes:explicit>clean</itunes:explicit>
            Duration    = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("duration")).First().Value;                      // <itunes:duration>5891</itunes:duration>
            Encoded     = ShowInfo.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("encoded")).First().Value;                       // <content:encoded>&lt;p&gt;Grey needs more storage space, Myke built a gaming PC (nice!), and they both talk about what they want to see at WWDC.&lt;/p&gt;</content:encoded>
        }
    }
}
