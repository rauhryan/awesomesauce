using AwesomeSauce.Configuration.Storage;

namespace AwesomeSauce.Handlers
{
    public class RestfulCreateHandler<TEntity>
        where TEntity : class
    {
        private readonly MongoSession _session;

        public RestfulCreateHandler(MongoSession session)
        {
            _session = session;
        }

        public RestfulCreateModel<TEntity> Execute(RestfulCreateRequest<TEntity> request)
        {
            var collection = _session.GetCollection<TEntity>();
            collection.Save(request.Model);

            return new RestfulCreateModel<TEntity>();
        }
         
    }

    public class RestfulCreateRequest<TEntity> where TEntity : class
    {
        public TEntity Model { get; set; }
    }

    public class RestfulCreateModel<TEntity> where TEntity : class
    {
        public bool success { get; set; }
    }
}