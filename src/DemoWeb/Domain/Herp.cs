using MongoDB.Bson;

namespace DemoWeb.Domain
{
    public class Herp : MyEntity
    {
        public string Name { get; set; }

        public ObjectId Id { get; set; }
    }
}