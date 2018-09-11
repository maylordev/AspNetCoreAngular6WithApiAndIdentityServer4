using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace LiveStreams.Api.Models
{
    public class LiveStreamsAppContext : DbContext
    {
        public LiveStreamsAppContext()
        {
        }
        public LiveStreamsAppContext(DbContextOptions<LiveStreamsAppContext> options)
            : base(options)
        {
        }
        public DbSet<ChannelModel> Channels { get; set; }
    }
}