using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Facade.Extensions;

public static class HttpRequestMessageExtenstion
{
    public static void SetJsonAsContent(this HttpRequestMessage request, object data)
    {
        var json = JsonSerializer.Serialize(data);
        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
    }
    
    public static void SetAuthorization(this HttpRequestMessage request, string? token)
    {
        if (token == null)
            return;

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
}