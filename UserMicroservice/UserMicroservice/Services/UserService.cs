using Google.Protobuf.Collections;
using Grpc.Core;
using MongoDB.Driver;
using UserMicroservice.Infrastructure.Data.Core;
using UserMicroservice.Infrastructure.Mapper;

namespace UserMicroservice.Services;

public class UserService : User.UserBase
{
    private readonly IAppDbContext _appDbContext;

    public UserService(IAppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public override async Task<CreateReply> CreateUser(CreateRequest request, ServerCallContext context)
    {
        var db = _appDbContext.GetDatabase();
        var collection = db.GetCollection<Infrastructure.Models.User>("Users");
        var user = new Infrastructure.Models.User
        {
            Id = Guid.NewGuid(),
            Login = request.Login,
            Email = request.Email,
            Password = request.Password
        };
        
        await collection.InsertOneAsync(user);
        
        return new CreateReply
        {
            Message = $"Success create user with login: {request.Login}"
        };
    }

    public override async Task<GetAllReply> GetUsers(GetAllRequest request, ServerCallContext context)
    {
        var db = _appDbContext.GetDatabase();
        var collection = db.GetCollection<Infrastructure.Models.User>("Users");
        var users = await collection.Find(_ => true).ToListAsync();

        // mapping user entity
        var mapper = MapperConfig.InitializeAutomapper();
        var list = users.Select(x => mapper.Map<UserEntity>(x));
        
        var reply = new GetAllReply();
        reply.Users.AddRange(list);
        return reply;

    }

    public override async Task<UpdateReply> UpdateUser(UpdateRequest request, ServerCallContext context)
    {
        var db = _appDbContext.GetDatabase();
        var collection = db.GetCollection<Infrastructure.Models.User>("Users");
        var filter = Builders<Infrastructure.Models.User>.Filter.Eq("login", request.User.Login);
        var update = Builders<Infrastructure.Models.User>.Update.Set("email", request.User.Email);

        await collection.UpdateOneAsync(filter, update);
        return new UpdateReply()
        {
            Message = "Successfully update!"
        };
    }

    public override async Task<DeleteReply> DeleteUser(DeleteRequest request, ServerCallContext context)
    {
        var db = _appDbContext.GetDatabase();
        var collection = db.GetCollection<Infrastructure.Models.User>("Users");
        var deleteFilter = Builders<Infrastructure.Models.User>.Filter.Eq("login", request.Login);

        await collection.DeleteOneAsync(deleteFilter);

        return new DeleteReply
        {
            Message = "Successfully delete!"
        };
    }
}