using MongoDB.Bson;

namespace DemoWeb.Domain
{
    public interface MyEntity
    {
        ObjectId Id { get; set; }
    }
}