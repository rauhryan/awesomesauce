using MongoDB.Bson;

namespace DemoWeb.Domain
{
    public class Derp : MyEntity
    {
        public ObjectId Id { get; set; }
        public string Herp { get; set; }
    }
}