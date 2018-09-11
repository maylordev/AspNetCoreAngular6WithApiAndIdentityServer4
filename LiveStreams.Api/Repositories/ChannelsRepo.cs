using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using LiveStreams.Api.Models;
using LiveStreams.Api.Models.Core;
using LiveStreams.Api.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace LiveStreams.Api.Repositories
{
    public interface IChannelRepository
    {
        Task<IEnumerable<ChannelModel>> GetAllChannels();
        Task<ChannelModel> FindById(string channelId);
    }
    public class ChannelRepository
    : BaseRepository<LiveStreamsAppContext, ChannelModel>, IChannelRepository
    {
        public ChannelRepository(DbContext dbContext, IConfiguration config) : base(dbContext, config)
        {
        }
        public async Task<ChannelModel> FindById(string channelId)
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = @"SELECT 
                                    Id, Title, Description, StreamUrl, ChannelId, SubscriptionId,
                                    BrandingImage, Branding  
                                FROM LiveStreamsApp.Channels
                                WHERE ID = @ID";
                conn.Open();
                var result = await conn.QueryAsync<ChannelModel>(
                    sQuery,
                    new { ID = channelId }
                );
                return result.FirstOrDefault();
            }
        }

        public async Task<IEnumerable<ChannelModel>> GetAllChannels()
        {
            using (IDbConnection conn = Connection)
            {
                string sQuery = "SELECT * FROM LiveStreamsApp.Channels";
                conn.Open();
                var result = await conn.QueryAsync<ChannelModel>(sQuery);
                return result.ToList();
            }
        }
    }
}