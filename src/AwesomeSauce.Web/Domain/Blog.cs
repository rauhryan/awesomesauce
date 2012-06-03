using MongoDB.Bson;

namespace AwesomeSauce.Web.Domain
{
    public class Blog : AwesomeEntity
    {
        public string Title { get; set; }
        public ObjectId Id { get; set; }
    }
}