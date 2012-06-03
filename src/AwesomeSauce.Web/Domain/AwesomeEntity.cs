using MongoDB.Bson;

namespace AwesomeSauce.Web.Domain
{
    public interface AwesomeEntity
    {
        ObjectId Id { get; set; }
    }
}