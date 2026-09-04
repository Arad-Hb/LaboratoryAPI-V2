using System.Text.Json.Serialization;

namespace Laboratory.Framework.Common;

/// <summary>
/// ساختار یکپارچه نتیجه عملیات بدون داده خروجی (پاسخ‌های استاندارد API)
/// </summary>
public class OperationResult
{
    [JsonPropertyName("isSuccess")]
    public bool IsSuccess { get; protected set; }

    [JsonPropertyName("message")]
    public string Message { get; protected set; } = string.Empty;

    [JsonPropertyName("statusCode")]
    public int StatusCode { get; protected set; }

    [JsonPropertyName("errorList")]
    public List<string> ErrorList { get; protected set; } = new();

    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; } = DateTime.UtcNow;

    protected OperationResult() { }

    public static OperationResult Success(string message = "عملیات با موفقیت انجام شد.", int statusCode = 200)
    {
        return new OperationResult
        {
            IsSuccess = true,
            Message = message,
            StatusCode = statusCode
        };
    }

    public static OperationResult Failure(string message = "خطایی در انجام عملیات رخ داده است.", int statusCode = 400, List<string>? errors = null)
    {
        return new OperationResult
        {
            IsSuccess = false,
            Message = message,
            StatusCode = statusCode,
            ErrorList = errors ?? new List<string>()
        };
    }

    public static OperationResult NotFound(string message = "رکورد مورد نظر یافت نشد.")
    {
        return Failure(message, 404);
    }

    public static OperationResult Unauthorized(string message = "دسترسی غیرمجاز است.")
    {
        return Failure(message, 401);
    }

    public static OperationResult Forbidden(string message = "شما اجازه انجام این عملیات را ندارید.")
    {
        return Failure(message, 403);
    }
}

/// <summary>
/// ساختار یکپارچه نتیجه عملیات همراه با داده خروجی جنریک
/// </summary>
/// <typeparam name="TData">نوع داده ارسالی به کلاینت</typeparam>
public class OperationResult<TData> : OperationResult
{
    [JsonPropertyName("data")]
    public TData? Data { get; private set; }

    private OperationResult() { }

    public static OperationResult<TData> Success(TData data, string message = "عملیات با موفقیت انجام شد.", int statusCode = 200)
    {
        return new OperationResult<TData>
        {
            IsSuccess = true,
            Message = message,
            StatusCode = statusCode,
            Data = data
        };
    }

    public new static OperationResult<TData> Failure(string message = "خطایی در انجام عملیات رخ داده است.", int statusCode = 400, List<string>? errors = null)
    {
        return new OperationResult<TData>
        {
            IsSuccess = false,
            Message = message,
            StatusCode = statusCode,
            ErrorList = errors ?? new List<string>()
        };
    }

    public new static OperationResult<TData> NotFound(string message = "اطلاعات مورد نظر یافت نشد.")
    {
        return Failure(message, 404);
    }
}
