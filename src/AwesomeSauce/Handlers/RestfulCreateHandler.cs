using AwesomeSauce.Configuration.Storage;
using FubuMVC.Core.Continuations;

namespace AwesomeSauce.Handlers
{
    public class RestfulCreateHandler<TEntity> where TEntity : class, new()
    {
        private readonly MongoSession _session;

        public RestfulCreateHandler(MongoSession session)
        {
            _session = session;
        }

        public FubuContinuation Execute(RestfulCreateRequest<TEntity> request)
        {
            var collection = _session.GetCollection<TEntity>();
            collection.Save(request.Entity);

            return FubuContinuation.RedirectTo(new RestfulIndexRequest<TEntity>());
        }
         
    }

    public class RestfulCreateRequest<T> where T : new()
    {
        public T Entity { get; set; }
    }

    public class RestfulCreateModel<TEntity> where TEntity : class
    {
        public bool success { get; set; }
    }
}
