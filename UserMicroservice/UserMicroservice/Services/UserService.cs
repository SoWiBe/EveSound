using Grpc.Core;
using UserMicroservice.Infrastructure.Data.Core;

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

    public override Task<GetAllReply> GetUsers(GetAllRequest request, ServerCallContext context)
    {
        return base.GetUsers(request, context);
    }

    public override Task<UpdateReply> UpdateUser(UpdateRequest request, ServerCallContext context)
    {
        return base.UpdateUser(request, context);
    }

    public override Task<DeleteReply> DeleteUser(DeleteRequest request, ServerCallContext context)
    {
        return base.DeleteUser(request, context);
    }
}