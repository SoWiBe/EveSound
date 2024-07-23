using Grpc.Core;

namespace UserMicroservice.Services;

public class UserService : User.UserBase
{
    public override async Task<CreateReply> CreateUser(CreateRequest request, ServerCallContext context)
    {
        return new CreateReply
        {
            Message = $"Success create user with login: {request.Login}"
        };
    }
}