using AwesomeSauce.Configuration.Storage;

namespace AwesomeSauce.Handlers
{
    public class RestfulCreateHandler<TEntity> where TEntity : class, new()
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

    public class RestfulCreateRequest<T> where T : new()
    {
        public RestfulCreateRequest()
        {
            Model = new T();
        }
        public T Model { get; set; }
    }

    public class RestfulCreateModel<TEntity> where TEntity : class
    {
        public bool success { get; set; }
    }
}
