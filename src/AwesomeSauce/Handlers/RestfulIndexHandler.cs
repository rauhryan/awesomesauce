using System.Collections.Generic;
using System.Linq;
using AwesomeSauce.Configuration.Storage;
using AwesomeSauce.Views;
using FubuMVC.Core.Urls;
using MongoDB.Driver.Linq;

namespace AwesomeSauce.Handlers
{
    public class RestfulIndexHandler<TEntity> where TEntity : class, new()
    {
        readonly MongoSession _session;
        readonly IUrlRegistry _urlRegistry;

        public RestfulIndexHandler(MongoSession session, IUrlRegistry urlRegistry)
        {
            _session = session;
            _urlRegistry = urlRegistry;
        }

        public RestfulIndexModel<TEntity> Execute(RestfulIndexRequest<TEntity> request)
        {
            var collection = _session.GetCollection<TEntity>();

            ICollection<TEntity> list = collection.AsQueryable().Select(e => e).ToArray();

            return new RestfulIndexModel<TEntity>() {Models = list};
        }

        public AwesomeIndexModel DaisyChain(RestfulIndexModel<TEntity> model)
        {

            var createUrl = _urlRegistry.UrlFor<AwesomeCreateHandler<TEntity>>(x => x.Execute());
            return new AwesomeIndexModel(){Models = model.Models, Header = typeof(TEntity).Name + "s", CreateUrl = createUrl};
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
