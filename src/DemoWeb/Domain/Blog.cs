using MongoDB.Bson;

namespace DemoWeb.Domain
{
    public class Blog : MyEntity
    {
        public string Title { get; set; }
        public ObjectId Id { get; set; }
    }
}