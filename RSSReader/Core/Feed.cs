using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.Core
{
    /// <summary>
    /// A class that represents an rss feed
    /// </summary>
    public class Feed
    {

        private string name;
        private string link;

        public Feed(string name, string link)
        {
            this.name = name;
            this.link = link;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

    }
}
