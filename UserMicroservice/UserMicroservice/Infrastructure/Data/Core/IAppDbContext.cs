using MongoDB.Driver;

namespace UserMicroservice.Infrastructure.Data.Core;

public interface IAppDbContext
{
    IMongoDatabase GetDatabase();
}