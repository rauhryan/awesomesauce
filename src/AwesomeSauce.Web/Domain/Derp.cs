using MongoDB.Bson;

namespace AwesomeSauce.Web.Domain
{
    public class Derp : AwesomeEntity
    {
        public ObjectId Id { get; set; }
        public string Herp { get; set; }
    }
}