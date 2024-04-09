using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Todo_Api.Models
{
    public class Todo
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status{ get; set;}
    }
}
