using MongoDB.Bson;

namespace DemoWeb.Domain
{
    public class Author : MyEntity
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}