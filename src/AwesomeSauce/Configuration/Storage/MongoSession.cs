using MongoDB.Driver;

namespace AwesomeSauce.Configuration.Storage
{
    public interface MongoSession
    {
        MongoDatabase Session { get; }     
    }

    public class DefaultMongoSession : MongoSession
    {
        private readonly MongoSettings _settings;
        private MongoServer _server;
        private MongoDatabase _database;

        public DefaultMongoSession(MongoSettings settings)
        {
            _settings = settings;
            _server = MongoServer.Create(settings.ConnectionString);
            _database = _server.GetDatabase(settings.Database);
        }

        public MongoDatabase Session
        {
            get { return _database; }
        }
    }
}