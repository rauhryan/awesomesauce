using AwesomeSauce.Configuration.Storage;
using FubuMVC.Core;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace AwesomeSauce.Handlers
{
    public class RestfulFindHandler<TEntity> where TEntity : class
    {
        private readonly MongoSession _session;

        public RestfulFindHandler(MongoSession session)
        {
            _session = session;
        }

        public RestfulIndexModel<TEntity> Get(RestfulIndexRequest<TEntity> request)
        {
            var collection = _session.Session.GetCollection<TEntity>(typeof (TEntity).Name.ToLowerInvariant());
            BsonValue id = new BsonObjectId(request.Id);
            var query = Query.EQ("_id", id);
            TEntity entity = collection.FindOne(query);
            return new RestfulIndexModel<TEntity>(){Model = entity};
        }
    }

    public class RestfulIndexRequest<T> : IRequestById
    {
        public string Id { get; set; }
    }

    public class RestfulIndexModel<T>
    {
        public T Model { get; set; }
    }

}