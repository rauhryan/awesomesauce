using MongoDB.Bson;

namespace AwesomeSauce.Web.Domain
{
    public class Author : AwesomeEntity
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}