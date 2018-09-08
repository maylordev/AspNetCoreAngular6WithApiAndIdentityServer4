using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LiveStreamsApp.Models
{
    public class LiveStreamsAppContext : DbContext
    {
        public LiveStreamsAppContext(DbContextOptions<LiveStreamsAppContext> options)
            : base(options)
        { }

        public DbSet<Channel> Channels { get; set; }
        public DbSet<Stream> Streams { get; set; }
    }

    public class Channel
    {
        public int Id { get; set; }
        public string ChannelId { get; set; }
        public string Url { get; set; }

        public List<Stream> Streams { get; set; }
    }

    public class Stream
    {
        public int Id { get; set; }
        public string StreamId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public string ChannelId { get; set; }
        public Channel Channel { get; set; }
    }
}