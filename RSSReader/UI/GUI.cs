using System;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel.Syndication;
using System.Drawing;
using RSSReader.Core;
using System.Collections.Generic;

namespace RSSReader
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private static List<Feed> feeds = new List<Feed>();

        private Feed getFeed(string name)
        {
            foreach(Feed f in feeds)
            {
                if(f.Name == name)
                {
                    return f;
                }
            }
            return null;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string link = linkBox.Text;
            feeds.Add(new Feed(name, link));
            TabPage newPage = new TabPage(name);
            newPage.Name = name;
            CreateRssFeed(link, newPage, false);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            feeds.Remove(getFeed(tabControl1.SelectedTab.Name));
            tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab.Controls.Clear();
            Feed selectedFeed = getFeed(tabControl1.SelectedTab.Name);
            CreateRssFeed(selectedFeed.Link, tabControl1.SelectedTab, true);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            string newName = newNameBox.Text;
            Feed selectedFeed = getFeed(tabControl1.SelectedTab.Name);
            selectedFeed.Name = newName;
            tabControl1.SelectedTab.Text = newName;
        }

        private void CreateRssFeed(string link, TabPage page, bool refresh)
        {
            try {
                XmlReader reader = XmlReader.Create(link);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();

                Panel content = new Panel();

                int line = 1;
                foreach (SyndicationItem item in feed.Items)
                {
                    string subject = item.Title.Text;
                    string summary = item.Summary.Text;
                    string time = item.PublishDate.ToString();

                    Label subjectLabel = new Label();
                    subjectLabel.Text = subject;
                    subjectLabel.AutoSize = true;
                    subjectLabel.Font = new Font(subjectLabel.Font, FontStyle.Bold);
                    subjectLabel.Location = new Point(10, line * 20); line++;

                    Label timeLabel = new Label();
                    timeLabel.Text = time;
                    timeLabel.AutoSize = true;
                    timeLabel.Font = new Font(timeLabel.Font, FontStyle.Italic);
                    timeLabel.Location = new Point(15, line * 20); line++;


                    Label summaryLabel = new Label();
                    summaryLabel.Text = Extensions.TrimEnd(summary, "<".ToCharArray()[0]);
                    summaryLabel.AutoSize = true;
                    summaryLabel.Location = new Point(15, line * 20); line++;


                    content.Controls.Add(subjectLabel);
                    content.Controls.Add(timeLabel);
                    content.Controls.Add(summaryLabel);
                }

                content.AutoScroll = true;
                content.BackColor = Color.White;
                content.Dock = DockStyle.Fill;
                page.Controls.Add(content);
                if (!refresh)
                    tabControl1.TabPages.Add(page);
            } catch(Exception e)
            {
                Panel content = new Panel();

                Label error = new Label();
                error.Text = "There was an error adding this Rss Feed "+link;
                error.AutoSize = true;
                error.Location = new Point(15, 10);
                Label exception = new Label();
                exception.Text = e.ToString();
                exception.AutoSize = true;
                exception.Location = new Point(15, 25);

                content.Controls.Add(error);
                content.Controls.Add(exception);

                content.AutoScroll = true;
                content.BackColor = Color.White;
                content.Dock = DockStyle.Fill;

                page.Controls.Add(content);
                if(!refresh)
                    tabControl1.TabPages.Add(page);
            }
        }
    }
}
