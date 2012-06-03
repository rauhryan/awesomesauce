using MongoDB.Bson;

namespace AwesomeSauce.Domain
{
    public interface AwesomeEntity
    {
        ObjectId Id { get; set; }
    }
}