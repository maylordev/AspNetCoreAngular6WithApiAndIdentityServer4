using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LiveStreams.Api.Models
{
    public class LiveStreamsAppContext
    {
        public string ConnectionString { get; set; }

        public LiveStreamsAppContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<ChannelModel> GetAllChannels()
        {
            List<ChannelModel> list = new List<ChannelModel>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Channels where id < 10", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ChannelModel()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            StreamUrl = reader["StreamUrl"].ToString(),
                            SubscriptionId = reader["SubscriptionId"].ToString()
                        });
                    }
                }
            }
            return list;
        }
    }
}