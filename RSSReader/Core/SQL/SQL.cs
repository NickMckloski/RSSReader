using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.Core.SQL
{
    public static class SQL
    {
        public static string datalocation()
        {
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            return "Data Source=" + dir + "\\rssfeeds.sqlite;";
        }

        public static void loadFeeds()
        {
            SQLiteConnection sqlConn = new SQLiteConnection(datalocation());
            sqlConn.Open();
            using (SQLiteCommand cmd = sqlConn.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM feeds";
                cmd.CommandType = CommandType.Text;
                SQLiteDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    GUI.feeds.Add(new Feed(Convert.ToString(reader["name"]), Convert.ToString(reader["link"])));
                }

            }
            sqlConn.Close();
        }

        public static void save()
        {
            SQLiteConnection sqlConn = new SQLiteConnection(datalocation());
            sqlConn.Open();
            foreach (Feed f in GUI.feeds)
            {
                SQLiteCommand cmd = new SQLiteCommand();
                cmd = sqlConn.CreateCommand();

                cmd.CommandText = "DELETE FROM feeds WHERE name=@name";
                cmd.Parameters.AddWithValue("@name", f.Name);
                cmd.ExecuteNonQueryAsync();
                cmd.Dispose();

                SQLiteCommand cmd2 = new SQLiteCommand();
                cmd2 = sqlConn.CreateCommand();
                cmd2.CommandText = "INSERT INTO feeds (name,link)  values (@name,@link)";
                cmd2.Parameters.AddWithValue("@name", f.Name);
                cmd2.Parameters.AddWithValue("@link", f.Link);
                cmd2.ExecuteNonQueryAsync();
                cmd2.Dispose();
            }
            sqlConn.Close();
        }

        public static void remove(Feed feed)
        {
            SQLiteConnection sqlConn = new SQLiteConnection(datalocation());
            sqlConn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd = sqlConn.CreateCommand();

            cmd.CommandText = "DELETE FROM feeds WHERE name=@name";
            cmd.Parameters.AddWithValue("@name", feed.Name);
            cmd.ExecuteNonQueryAsync();
            cmd.Dispose();

            sqlConn.Close();
        }

        public static void rename(string oldName, Feed feed)
        {
            SQLiteConnection sqlConn = new SQLiteConnection(datalocation());
            sqlConn.Open();
            SQLiteCommand cmd = new SQLiteCommand();
            cmd = sqlConn.CreateCommand();

            cmd.CommandText = "DELETE FROM feeds WHERE name=@name";
            cmd.Parameters.AddWithValue("@name", oldName);
            cmd.ExecuteNonQueryAsync();
            cmd.Dispose();

            SQLiteCommand cmd2 = new SQLiteCommand();
            cmd2 = sqlConn.CreateCommand();
            cmd2.CommandText = "INSERT INTO feeds (name,link)  values (@name,@link)";
            cmd2.Parameters.AddWithValue("@name", feed.Name);
            cmd2.Parameters.AddWithValue("@link", feed.Link);
            cmd2.ExecuteNonQueryAsync();
            cmd2.Dispose();

            sqlConn.Close();
        }
    }
}
