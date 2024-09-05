using Facade.Errors;

namespace Facade.Abstractions.Repositories;

public interface IApiRepository
{
    Task<ErrorOr<TResponse?>> PostDataWithResponseAsync<TResponse>(string url, object data, string? token = null);
    Task<ErrorOr<TResponse?>> GetResponseAsync<TResponse>(string url, string? token = null);
    Task<ErrorOr<TResponse?>> DeleteResponseAsync<TResponse>(string url, string? token = null);
    Task<ErrorOr<TResponse?>> PutDataWithResponseAsync<TResponse>(string url, object data, string? token = null);
}