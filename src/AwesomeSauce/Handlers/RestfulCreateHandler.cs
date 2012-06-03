using AwesomeSauce.Configuration.Storage;

namespace AwesomeSauce.Handlers
{
    public class RestfulCreateHandler<TEntity> 
    {
        private readonly MongoSession _session;

        public RestfulCreateHandler(MongoSession session)
        {
            _session = session;
        }

        public RestfulCreateModel<TEntity> Post(RestfulCreateRequest<TEntity> request)
        {
            var collection = _session.Session.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
            collection.Save(request.Model);

            return new RestfulCreateModel<TEntity>();
        }
         
    }

    public class RestfulCreateRequest<T>
    {
        public T Model { get; set; }
    }

    public class RestfulCreateModel<T>
    {
        public bool success { get; set; }
    }
}