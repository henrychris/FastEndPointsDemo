using Newtonsoft.Json;

namespace FastEndPointsDemo.Models;

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public class ApiResponse<T> // where T : class
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }

    /// <summary>
    /// 
    /// </summary>
    public ApiResponse()
    {
        IsSuccessful = false;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="apiVersion"></param>
    /// <param name="success"></param>
    /// <param name="referenceId"></param>
    /// <param name="message"></param>
    /// <param name="error"></param>
    public ApiResponse(T? data, string apiVersion, bool success, string? referenceId, string? message,
        ApiError? error = null)
    {
        Data = data;
        ApiVersion = apiVersion;
        IsSuccessful = success;
        Code = success ? ResponseCodes.SUCCESSFUL : ResponseCodes.UNSUCCESSFUL;
        ReferenceId = referenceId;
        Message = message;
        Error = error;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <param name="referenceId"></param>
    /// <param name="message"></param>
    public ApiResponse(T? data, string? referenceId, string? message)
    {
        Data = data;
        IsSuccessful = true;
        Code = ResponseCodes.SUCCESSFUL;
        ReferenceId = referenceId;
        Message = string.IsNullOrEmpty(message) ? Status.Successful.ToString() : message;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isSuccessful"></param>
    /// <param name="data"></param>
    /// <param name="message"></param>
    public ApiResponse(bool isSuccessful, T? data, string? message)
    {
        IsSuccessful = isSuccessful;
        Code = isSuccessful ? ResponseCodes.SUCCESSFUL : ResponseCodes.UNSUCCESSFUL;
        Data = data;
        Message = message;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isSuccessful"></param>
    public ApiResponse(bool isSuccessful)
    {
        IsSuccessful = isSuccessful;
        Code = isSuccessful ? ResponseCodes.SUCCESSFUL : ResponseCodes.UNSUCCESSFUL;
        if (typeof(T).IsAssignableFrom(typeof(bool)))
        {
            Data = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(isSuccessful));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    public ApiResponse(T? data)
    {
        Data = data;
        IsSuccessful = true;
        Code = ResponseCodes.SUCCESSFUL;
        Message = Status.Successful.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="error"></param>
    public ApiResponse(ApiError? error)
    {
        IsSuccessful = false;
        Code = ResponseCodes.UNSUCCESSFUL;
        Error = error;
        Message = Status.Unsuccessful.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string ApiVersion { get; set; } = "v1";

    /// <summary>
    /// 
    /// </summary>
    public bool IsSuccessful { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? ReferenceId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ApiError? Error { get; set; }
}

public class ApiError
{
    /// <summary>
    /// 
    /// </summary>
    public ApiError()
    {
    }

    /// <summary>
    /// h
    /// </summary>
    /// <param name="message"></param>
    /// <param name="code"></param>
    public ApiError(string? message, string? code)
    {
        Message = message;
        Code = code;
    }

    /// <summary>
    /// 
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Code { get; set; }
}