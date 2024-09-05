using Facade.Abstractions.Repositories;
using Facade.Errors;

namespace Facade.Infrastructure.Repositories;

public class ApiRepository : IApiRepository
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IJsonRepository _jsonRepository;

    public ApiRepository(IHttpClientFactory httpClientFactory, IJsonRepository jsonRepository)
    {
        _httpClientFactory = httpClientFactory;
        _jsonRepository = jsonRepository;
    }

    public async Task<ErrorOr<TResponse?>> PostDataWithResponseAsync<TResponse>(string url, object data, string? token = null)
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<TResponse?>> GetResponseAsync<TResponse>(string url, string? token = null)
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<TResponse?>> DeleteResponseAsync<TResponse>(string url, string? token = null)
    {
        throw new NotImplementedException();
    }

    public async Task<ErrorOr<TResponse?>> PutDataWithResponseAsync<TResponse>(string url, object data, string? token = null)
    {
        throw new NotImplementedException();
    }
}