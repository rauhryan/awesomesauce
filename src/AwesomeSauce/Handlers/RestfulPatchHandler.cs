using AwesomeSauce.Configuration.Storage;
using MongoDB.Driver.Builders;

namespace AwesomeSauce.Handlers
{
    public class RestfulPatchHandler<TEntity> where TEntity : class
    {
        private readonly MongoSession _session;

        public RestfulPatchHandler(MongoSession session)
        {
            _session = session;
        }

        public RestfulPatchModel<TEntity> Patch(RestfulPatchRequest<TEntity> request)
        {
            var collection = _session.GetCollection<TEntity>();

            var query = Query.EQ("_id", request.Id);
            var entity = collection.FindOne(query);

            merge(entity, request.Model);

            collection.Save(entity);

            return new RestfulPatchModel<TEntity>(){success = true};
        }

        void merge(TEntity entity, TEntity model)
        {
            //do nothing for now
        }
    }

    public class RestfulPatchModel<T>
    {
        public bool success { get; set; }
    }

    public class RestfulPatchRequest<T> :
        IRequestById
    {
        public string Id { get; set; }
        public T Model { get; set; }
    }
}