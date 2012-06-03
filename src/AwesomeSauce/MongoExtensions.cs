using AwesomeSauce.Configuration.Storage;
using MongoDB.Driver;

namespace AwesomeSauce
{
    public static class MongoExtensions
    {
         public static MongoCollection<TEntity> GetCollection<TEntity>(this MongoSession session)
         {
             return session.Session.GetCollection<TEntity>(typeof(TEntity).Name.ToLowerInvariant());
         }
    }
}