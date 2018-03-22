using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BannerFlow.Models;
using MongoDB.Driver;
using System.Configuration;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System.Diagnostics;

namespace BannerFlow.Repositories
{
    public class BannerRepository : IBannerRepository
    {
        private MongoClient client = null;
        private MongoServer server = null;
        private MongoDatabase db = null;
        private MongoCollection<Banner> banners = null;

        public BannerRepository()
        {
            client = new MongoClient(ConfigurationManager.AppSettings["MongoDBConnectionString"]);
            server = client.GetServer();
            db = server.GetDatabase(ConfigurationManager.AppSettings["MongoDBDatabaseName"]);
            banners = db.GetCollection<Banner>(ConfigurationManager.AppSettings["MongoDBCollection"]);

        }

        public int GetLastKey()
        {
            List<Banner> list = new List<Banner>();
            if (this.banners.Count() == 0)
                return 0;
            list = this.banners.FindAll().ToList();
            return list[list.Count()-1].Id;
        }

        public Banner Add(Banner item)
        {
            var result = this.banners.Save(item);
            if(result.DocumentsAffected == 0 && result.HasLastErrorMessage)
            {
                Trace.TraceError(result.LastErrorMessage);
            }

            return item;
        }

        public Banner Get(int id)
        {
            Banner result = null;
            var partialResult = this.banners.AsQueryable<Banner>()
                .Where(p => p.Id == id)
                .ToList();

            result = partialResult.Count > 0
                ? partialResult[0]
                : null;

            return result;
        }

        public IEnumerable<Banner> GetAll()
        {
            List<Banner> result = new List<Banner>();
            result = this.banners.FindAll().ToList();
            return result;
        }

        public void Delete(int id)
        {
            var query = Query<Banner>.EQ(p => p.Id, id);
            var result = this.banners.Remove(query);
            if(result.DocumentsAffected == 0 && result.HasLastErrorMessage)
            {
                Trace.TraceError(result.LastErrorMessage);
            }
        }

        public Banner Update(int id, Banner item)
        {
            var query = Query<Banner>.EQ(p => p.Id, id);
            var update = Update<Banner>.Set(p => p.Html, item.Html)
                                        .Set(p => p.Modified, item.Modified);

            var result = this.banners.Update(query, update);
            if(result.DocumentsAffected == 0 && result.HasLastErrorMessage)
            {
                Trace.TraceError(result.LastErrorMessage);
            }

            return item;
        }
    }
}