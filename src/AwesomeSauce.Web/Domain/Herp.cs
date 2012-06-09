using MongoDB.Bson;

namespace AwesomeSauce.Web.Domain
{
    public class Herp : AwesomeEntity
    {
        public string Name { get; set; }

        public ObjectId Id { get; set; }
    }
}