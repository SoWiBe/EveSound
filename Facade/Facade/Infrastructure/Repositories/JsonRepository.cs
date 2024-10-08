﻿using System.Text.Json;
using Facade.Abstractions.Repositories;

namespace Facade.Infrastructure.Repositories;

public class JsonRepository : IJsonRepository
{
    public Task<TResult?> Deserialize<TResult>(string json)
    {
        var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        var result = JsonSerializer.Deserialize<TResult>(json, options);
        return Task.FromResult(result);
    }

    public Task<string> Serialize(object data)
    {
        var result = JsonSerializer.Serialize(data);
        return Task.FromResult(result);
    }
}