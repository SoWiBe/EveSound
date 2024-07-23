using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UserMicroservice.Infrastructure.Models;

public class User
{
    [BsonId]
    [BsonGuidRepresentation(GuidRepresentation.Standard)]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [BsonElement("login")] public string Login { get; set; }
    [BsonElement("email")] public string Email { get; set; }
    [BsonElement("password")] public string Password { get; set; }
}