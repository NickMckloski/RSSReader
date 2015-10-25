using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace RSSReader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(nameBox.Text);
            Console.WriteLine(linkBox.Text);
            TabPage newFeed = new TabPage(nameBox.Text);
            tabControl1.TabPages.Add(newFeed);
        }



        private void removeButton_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab.Text = newNameBox.Text;
        }

        private string ParseRss(string Link)
        {
            XmlDocument rssXmlDoc = new XmlDocument();

            // Load the RSS file from the RSS URL
            rssXmlDoc.Load("http://feeds.feedburner.com/techulator/articles");

            // Parse the Items in the RSS file
            XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");

            StringBuilder rssContent = new StringBuilder();

            // Iterate through the items in the RSS file
            foreach (XmlNode rssNode in rssNodes)
            {
                XmlNode rssSubNode = rssNode.SelectSingleNode("title");
                string title = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("link");
                string link = rssSubNode != null ? rssSubNode.InnerText : "";

                rssSubNode = rssNode.SelectSingleNode("description");
                string description = rssSubNode != null ? rssSubNode.InnerText : "";

                rssContent.Append("<a href='" + link + "'>" + title + "</a><br>" + description);
            }

            // Return the string that contain the RSS items
            return rssContent.ToString();
        }
    }
}
