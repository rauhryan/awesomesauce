using MongoDB.Driver;
using StructureMap.Configuration.DSL;

namespace AwesomeSauce.Configuration.Storage
{
    public class StorageRegistry : Registry
    {
        public StorageRegistry()
        {
            ForSingletonOf<MongoSession>()
                .Use<DefaultMongoSession>();
        }
    }
}