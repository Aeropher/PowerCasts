using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerCasts
{
    class Program
    {
        static void Main(string[] args)
        {
            string feed = "https://www.relay.fm/cortex/feed";

            Channel Cortex = new Channel(feed);

        }
    }
}
