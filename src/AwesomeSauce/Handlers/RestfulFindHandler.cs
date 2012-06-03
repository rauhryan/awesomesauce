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

        public RestfulFindModel<TEntity> Get(RestfulFindRequest<TEntity> request)
        {
            var collection = _session.Session.GetCollection<TEntity>(typeof (TEntity).Name.ToLowerInvariant());
            BsonValue id = new BsonObjectId(request.Id);
            var query = Query.EQ("_id", id);
            TEntity entity = collection.FindOne(query);
            return new RestfulFindModel<TEntity>(){Model = entity};
        }
    }

    public class RestfulFindRequest<T> : IRequestById
    {
        public string Id { get; set; }
    }

    public class RestfulFindModel<T>
    {
        public T Model { get; set; }
    }

}