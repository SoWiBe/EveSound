
using Grpc.Net.Client;
using TestClient;

using var channel = GrpcChannel.ForAddress("https://localhost:7054/");
var client = new User.UserClient(channel);
Console.Write("Write name: ");
var name = Console.ReadLine();

var reply = await client.CreateUserAsync(new CreateRequest()
{
    Login = name,
    Email = "test",
    Password = "test"
});

Console.Write($"Server response: {reply.Message}");
