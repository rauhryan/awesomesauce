using System.Collections.Generic;
using System.Linq;
using AwesomeSauce.Configuration.Storage;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace AwesomeSauce.Handlers
{
    public class RestfulIndexHandler<TEntity> where TEntity : class
    {
        private readonly MongoSession _session;

        public RestfulIndexHandler(MongoSession session)
        {
            _session = session;
        }

        public RestfulIndexModel<TEntity> Get(RestfulIndexRequest<TEntity> request)
        {
            var collection = _session.Session.GetCollection<TEntity>(typeof (TEntity).Name.ToLowerInvariant());
          
            ICollection<TEntity> list = collection.AsQueryable<TEntity>().Select(e => e).ToArray();

            return new RestfulIndexModel<TEntity>() { Models = list };
        }
    }

    public class RestfulIndexModel<T>
    {
        public ICollection<T> Models { get; set; }
    }

    public class RestfulIndexRequest<T>
    {
    }
}