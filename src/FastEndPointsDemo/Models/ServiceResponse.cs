namespace FastEndPointsDemo.Models;

/// <summary>
/// This is the response class for all application services and integrations
/// </summary>
/// <typeparam name="T"></typeparam>
public class ServiceResponse<T> //where T : class?
{
    /// <summary>
    /// 
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public T? Data { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ServiceError? Error { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string GetResponseCode()
    {
        if (!string.IsNullOrEmpty(Error?.Code)) return Error.Code;
        return IsSuccess ? ResponseCodes.UNSUCCESSFUL : ResponseCodes.SUCCESSFUL;
    }

    public ServiceResponse()
    {
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isSuccess"></param>
    public ServiceResponse(bool isSuccess)
    {
        IsSuccess = isSuccess;
        Message = isSuccess ? Status.Successful.ToString() : Status.Unsuccessful.ToString();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    public ServiceResponse(T? data)
    {
        IsSuccess = true;
        Message = Status.Successful.ToString();
        Data = data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="message"></param>
    /// <param name="data"></param>
    public ServiceResponse(bool isSuccess, string message, T? data)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }
}

public class ServiceError
{
    /// <summary>
    /// 
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Code { get; set; }
}

/// <summary>
/// This is the response class for all application services and integrations
/// </summary>
public class ServiceResponse
{
    /// <summary>
    /// 
    /// </summary>
    public string? Reference { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? RequestId { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public bool IsSuccess { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public object? Data { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public ServiceError? Error { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public string? GetResponseCode()
    {
        if (string.IsNullOrEmpty(Error?.Code))
        {
            if (IsSuccess)
            {
                return ResponseCodes.UNSUCCESSFUL;
            }
            else
            {
                return ResponseCodes.SUCCESSFUL;
            }
        }

        return Error?.Code;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isSuccess"></param>
    public ServiceResponse(bool isSuccess)
    {
        IsSuccess = isSuccess;
        if (isSuccess)
        {
            Message = Status.Successful.ToString();
        }
        else
        {
            Message = Status.Unsuccessful.ToString();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    public ServiceResponse(dynamic? data = null)
    {
        IsSuccess = true;
        Message = Status.Successful.ToString();
        Data = data;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="isSuccess"></param>
    /// <param name="message"></param>
    /// <param name="data"></param>
    public ServiceResponse(bool isSuccess, string message, dynamic? data = null)
    {
        IsSuccess = isSuccess;
        Message = message;
        Data = data;
    }
}