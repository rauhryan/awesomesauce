using AwesomeSauce.Configuration.Storage;
using AwesomeSauce.Views;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace AwesomeSauce.Handlers
{
    public class AwesomeEditHandler<TEntity> where TEntity : class 
    {
        readonly MongoSession _session;

        public AwesomeEditHandler(MongoSession session)
        {
            _session = session;
        }

        public AwesomeEditModel Execute(AwesomeEditRequest<TEntity> request)
         {
             var collection = _session.GetCollection<TEntity>();

             var query = Query.EQ("_id", new BsonObjectId(request.Id));
             var entity = collection.FindOne(query);

             return new AwesomeEditModel{Entity = entity};
        }

        public AwesomeEditModel DaisyChain(AwesomeEditModel<TEntity> model)
        {
            return new AwesomeEditModel(){Entity = model.Entity};
        }
    }

   public class AwesomeEditModel<T>
   {
       public T Entity { get; set; }
   }

  
    public class AwesomeEditRequest<T> : IRequestById
    {
        public string Id { get; set; }
        
    }
}
