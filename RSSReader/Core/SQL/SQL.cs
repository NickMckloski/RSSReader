using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSSReader.Core.SQL
{
    public static class SQL
    {

        public static string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        /// <summary>
        /// Returns the location of the sqlite file
        /// </summary>
        /// <returns></returns>
        public static string datalocation()
        {
            return "Data Source=" + dir + "\\rssfeeds.sqlite;";
        }

        /// <summary>
        /// This method will create the database file if it dosn't exist
        /// </summary>
        public static void createDb()
        {
            if (!File.Exists(dir + "\\rssfeeds.sqlite"))
            {
                SQLiteConnection.CreateFile(dir + "\\rssfeeds.sqlite");

                SQLiteConnection sqlConn = new SQLiteConnection(datalocation());
                sqlConn.Open();

                string sql = "CREATE TABLE feeds (name string, link string)";

                SQLiteCommand command = new SQLiteCommand(sql, sqlConn);
                command.ExecuteNonQuery();

                sqlConn.Close();
            }
        }

        /// <summary>
        /// Loads the feeds from the sqlite db
        /// </summary>
        public static void loadFeeds()
        {
            createDb();
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

        /// <summary>
        /// Saves to sqlite db
        /// </summary>
        public static void save()
        {
            createDb();
            SQLiteConnection sqlConn = new SQLiteConnection(datalocation());
            sqlConn.Open();
            foreach (Feed f in GUI.feeds)
            {
                using (SQLiteCommand cmd = sqlConn.CreateCommand())
                {
                    cmd.CommandText = "REPLACE INTO `feeds` (name, link) VALUES (@name, @link)";
                    cmd.Parameters.AddWithValue("@name", f.Name);
                    cmd.Parameters.AddWithValue("@link", f.Link);
                    cmd.ExecuteNonQueryAsync();
                }
            }
            sqlConn.Close();
        }

        /// <summary>
        /// Removes the given feed
        /// </summary>
        /// <param name="feed">Feed to remove</param>
        public static void remove(Feed feed)
        {
            createDb();
            SQLiteConnection sqlConn = new SQLiteConnection(datalocation());
            sqlConn.Open();
            using (SQLiteCommand cmd = sqlConn.CreateCommand())
            {
                cmd.CommandText = "DELETE FROM feeds WHERE name=@name";
                cmd.Parameters.AddWithValue("@name", feed.Name);
                cmd.ExecuteNonQueryAsync();
            }
            sqlConn.Close();
        }

        /// <summary>
        /// Renames a given feed
        /// </summary>
        /// <param name="oldName">The "old" name of the feed</param>
        /// <param name="feed">Feed object being used</param>
        public static void rename(string oldName, string newName)
        {
            createDb();
            SQLiteConnection sqlConn = new SQLiteConnection(datalocation());
            sqlConn.Open();
            using (SQLiteCommand cmd = sqlConn.CreateCommand())
            {
                cmd.CommandText = "UPDATE feeds SET name=@newName WHERE name=@oldname";
                cmd.Parameters.AddWithValue("@oldname", oldName);
                cmd.Parameters.AddWithValue("@newName", newName);
                cmd.ExecuteNonQueryAsync();
            }
            sqlConn.Close();
        }
    }
}
