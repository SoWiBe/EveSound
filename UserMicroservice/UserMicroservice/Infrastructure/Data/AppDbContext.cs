using MongoDB.Driver;
using UserMicroservice.Infrastructure.Data.Core;

namespace UserMicroservice.Infrastructure.Data;

public class AppDbContext : IAppDbContext
{
    private readonly MongoClient _client;

    public AppDbContext(string connection)
    {
        _client = new MongoClient(connection);
    }

    public IMongoDatabase GetDatabase() => _client.GetDatabase("EveSound");
}