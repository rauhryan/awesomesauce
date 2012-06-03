namespace AwesomeSauce.Configuration.Storage
{
    public class MongoSettings
    {
        public MongoSettings()
        {
            ConnectionString = "mongodb://localhost/?safe=true";
            Database = "awesomesauce";
        }

        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}