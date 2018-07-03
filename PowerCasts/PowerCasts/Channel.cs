using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace PowerCasts
{
    // Based on the RSS feed from Relay.FM
    class Channel
    {
        public string Title { get; set; }       //<title>Cortex</title>
        public string Link { get; set; }        //<link>https://www.relay.fm/cortex</link>
        public string PublishDate { get; set; } //<pubDate>Mon, 11 Jun 2018 11:45:00 GMT</pubDate>
        public string Description { get; set; } //<description>CGP Grey and Myke Hurley are both independent content creators.Each episode, they get together to discuss their working lives. Hosted by CGP Grey and Myke Hurley.</description>
        public string Language { get; set; }    //<language>en-US</language>
        public string Copyright { get; set; }   //<copyright>Copyright © 2018 Relay FM</copyright>
        public string Author { get; set; }      //<itunes:author>Relay FM</itunes:author>
        public string Keywords { get; set; }    //<itunes:keywords>cgp, grey, myke, hurley, work, time, technology, productivity, getting, things, done</itunes:keywords>
        public string Explicit { get; set; }    //<itunes:explicit>clean</itunes:explicit>
        public string Image { get; set; }       //<itunes:image href = "http://relayfm.s3.amazonaws.com/uploads/broadcast/image/17/cortex_artwork.png" />
        public string OwnerName { get; set; }   //<itunes:name>Relay FM</itunes:name>
        public string OwnerEmail { get; set; }  //<itunes:email>hello @relay.fm</itunes:email>
        public string Block { get; set; }       //<itunes:block>no</itunes:block>
        public string Category { get; set; }    //<itunes:category text = "Technology" />

        public IList<Podcast> Shows = new List<Podcast>();


        public Channel(string RssFeed)
        {
            XDocument PodcastFeed = XDocument.Load(RssFeed);

            // Note that the following assumes that this information will be at the top of the feed 
            // So for example, the first instance of "<Title>" will be the title of the channel and not one of the shows
            Title       = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("title")).First().Value;                      //<title>Cortex</title>
            Link        = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("link")).First().Value;                       //<link>https://www.relay.fm/cortex</link>
            PublishDate = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("pubdate")).First().Value;                    //<pubDate>Mon, 11 Jun 2018 11:45:00 GMT</pubDate>
            Description = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("description")).First().Value;                //<description>CGP Grey and Myke Hurley are both independent content creators.Each episode, they get together to discuss their working lives. Hosted by CGP Grey and Myke Hurley.</description>
            Language    = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("language")).First().Value;                   //<language>en-US</language>
            Copyright   = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("copyright")).First().Value;                  //<copyright>Copyright © 2018 Relay FM</copyright>
            Author      = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("author")).First().Value;                     //<itunes:author>Relay FM</itunes:author>
            Keywords    = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("keywords")).First().Value;                   //<itunes:keywords>cgp, grey, myke, hurley, work, time, technology, productivity, getting, things, done</itunes:keywords>
            Explicit    = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("explicit")).First().Value;                   //<itunes:explicit>clean</itunes:explicit>
            Image       =  PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("image")).First().Attribute("href").Value;   //<itunes:image href = "http://relayfm.s3.amazonaws.com/uploads/broadcast/image/17/cortex_artwork.png" />
            OwnerName   = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("name")).First().Value;                       //<itunes:name>Relay FM</itunes:name>
            OwnerEmail  = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("email")).First().Value;                      //<itunes:email>hello @relay.fm</itunes:email>
            Block       = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("block")).First().Value;                      //<itunes:block>no</itunes:block>
            Category    = PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("category")).First().Attribute("text").Value; //<itunes:category text = "Technology" />

            // Loop through all item tags; pass into Podcast Constructor; add to Shows list.

            foreach (XElement item in PodcastFeed.Descendants().Where((x) => x.Name.LocalName.ToLowerInvariant().Equals("item")))
            {
                Shows.Add(new Podcast(item));
            }
        }
    }
}
