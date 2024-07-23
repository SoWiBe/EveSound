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