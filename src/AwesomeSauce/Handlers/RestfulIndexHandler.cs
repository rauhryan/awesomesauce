using System.Collections.Generic;
using System.Linq;
using AwesomeSauce.Configuration.Storage;
using MongoDB.Driver.Linq;

namespace AwesomeSauce.Handlers
{
    public class RestfulIndexHandler<TEntity> where TEntity : class
    {
        readonly MongoSession _session;

        public RestfulIndexHandler(MongoSession session)
        {
            _session = session;
        }

        public RestfulIndexModel<TEntity> Get(RestfulIndexRequest<TEntity> request)
        {
            var collection = _session.GetCollection<TEntity>();

            ICollection<TEntity> list = collection.AsQueryable().Select(e => e).ToArray();

            return new RestfulIndexModel<TEntity>() {Models = list};
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
