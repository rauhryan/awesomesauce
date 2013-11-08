using DemoWeb.Configuration;
using MongoDB.Bson;

namespace DemoWeb.Domain
{
    public class Loan : IEntity
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public LoanNumber LoanNumber { get; set; }
    }
}