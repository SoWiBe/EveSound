using Facade.Abstractions.Errors;
using Facade.Abstractions.Repositories;
using Facade.Errors;
using Facade.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        var client = _httpClientFactory.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Post, url);
        request.SetJsonAsContent(data);
        request.SetAuthorization(token);

        return await SendWithResponse<TResponse>(client, request);
    }

    public async Task<ErrorOr<TResponse?>> GetResponseAsync<TResponse>(string url, string? token = null)
    {
        var client = _httpClientFactory.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Get, url);
        request.SetAuthorization(token);

        return await SendWithResponse<TResponse>(client, request);
    }

    public async Task<ErrorOr<TResponse?>> DeleteResponseAsync<TResponse>(string url, object data, string? token = null)
    {
        var client = _httpClientFactory.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        request.SetJsonAsContent(data);
        request.SetAuthorization(token);

        return await SendWithResponse<TResponse>(client, request);
    }

    public async Task<ErrorOr<TResponse?>> PutDataWithResponseAsync<TResponse>(string url, object data, string? token = null)
    {
        var client = _httpClientFactory.CreateClient();

        var request = new HttpRequestMessage(HttpMethod.Put, url);
        request.SetJsonAsContent(data);
        request.SetAuthorization(token);
        
        return await SendWithResponse<TResponse>(client, request);
    }
    
    private async Task<ErrorOr<TResponse?>> SendWithResponse<TResponse>(HttpClient client, HttpRequestMessage request)
    {
        try
        {
            var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead);
            var res = await response.Content.ReadAsStringAsync();
             if (!response.IsSuccessStatusCode)
                return Error.Unexpected(ConvertCode(res), Convert(res));
            
            var responseContent = await response.Content.ReadAsStringAsync();
            var result = await _jsonRepository.Deserialize<TResponse>(responseContent);
            
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return Error.Unexpected("Api.Unexpected", e.ToString());
        }
    }
    
    private string Convert(string response)
    {
        try
        {
            var json = JsonConvert.DeserializeObject<JObject>(response);
            var description =
                (json?.SelectToken("detail[0].msg") ?? json?.SelectToken("detail") ?? json?.SelectToken("description"))
                ?.ToString();

            return string.IsNullOrEmpty(description) ? "Unexpected error" : description;
        }
        catch (Exception)
        {
            return "Unexpected error";
        }
    }
    
    private string ConvertCode(string response)
    {
        try
        {
            var json = JsonConvert.DeserializeObject<JObject>(response);
            var code = json?.SelectToken("code")?.ToString();

            return string.IsNullOrEmpty(code) ? "Api.Unexpected" : code;
        }
        catch (Exception)
        {
            return "Api.Unexpected";
        }
    }
}