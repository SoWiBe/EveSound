using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace Common.Models.Files;

public class FileInfoModel
{
    [JsonPropertyName("fileDetails")] public IFormFile FileDetails { get; set; }
    [JsonPropertyName("fileType")] public FileType FileType { get; set; }
}