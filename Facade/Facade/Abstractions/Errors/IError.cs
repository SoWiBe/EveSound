using System.Text.Json.Serialization;

namespace Facade.Abstractions.Errors;

public interface IErrorOr
{
    List<Error>? Errors { get; }
    bool IsError { get; }
}

public readonly record struct Error
{
    public string Code { get; }

    public string Description { get; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ErrorType Type { get; }

    public int NumericType { get; }

    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
        NumericType = (int)type;
    }

    public static Error Failure(
        string code = "General.Failure",
        string description = "A failure has occurred.") =>
        new(code, description, ErrorType.Failure);

    public static Error Unexpected(
        string code = "General.Unexpected",
        string description = "An unexpected error has occurred.") =>
        new(code, description, ErrorType.Unexpected);

    public static Error Validation(
        string code = "General.Validation",
        string description = "A validation error has occurred.") =>
        new(code, description, ErrorType.Validation);

    public static Error Conflict(
        string code = "General.Conflict",
        string description = "A conflict error has occurred.") =>
        new(code, description, ErrorType.Conflict);

    public static Error NotFound(
        string code = "General.NotFound",
        string description = "A 'Not Found' error has occurred.") =>
        new(code, description, ErrorType.NotFound);

    public static Error Custom(
        int type,
        string code,
        string description) =>
        new(code, description, (ErrorType)type);

    public override string ToString()
    {
        return
            $"{{\n    \"code\": \"{Code}\",\n    \"description\": \"{Description}\",\n    \"type\": \"{Type}\",\n    " +
            $"\"numericType\": {NumericType}\n}}";
    }
}

public enum ErrorType
{
    Failure = 0,
    Unexpected = 1,
    Validation = 2,
    Conflict = 3,
    NotFound = 4,
    BadRequest = 5,
    Unauthorized = 6,
    PaymentRequired = 7,
    UnprocessableContent = 8,
    Forbidden = 9
}
