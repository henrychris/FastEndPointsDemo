namespace FastEndPointsDemo.Models;

/// <summary>
/// 
/// </summary>
public static class ReturnedServiceResponse
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ServiceResponse ModelStateResponse(string message, object data)
    {
        var apiResp = new ServiceResponse
        {
            Data = data,
            IsSuccess = false,
            Message = Status.Unsuccessful.ToString(),
            Code = "400"
        };
        var error = new ServiceError
        {
            Message = message
        };
        apiResp.Error = error;

        return apiResp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ServiceResponse ErrorResponse(string? message = null, object? data = null)
    {
        var apiResp = new ServiceResponse
        {
            Data = data,
            IsSuccess = false,
            Message = Status.Unsuccessful.ToString(),
            Code = "400"
        };
        var error = new ServiceError
        {
            Message = message
        };
        apiResp.Error = error;

        return apiResp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="code"></param>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ServiceResponse ErrorResponse(string? message = null, object? data = null, string? code = null)
    {
        var apiResp = new ServiceResponse
        {
            Data = data,
            IsSuccess = false,
            Message = Status.Unsuccessful.ToString(),
            Code = string.IsNullOrEmpty(code) ? "400" : code
        };

        var error = new ServiceError
        {
            Message = message
        };
        apiResp.Error = error;

        return apiResp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <param name="referenceId"></param>
    /// <returns></returns>
    public static ServiceResponse SuccessResponse(string? message, object data, string referenceId = "")
    {
        var apiResp = new ServiceResponse
        {
            Data = data,
            IsSuccess = true,
            Reference = referenceId,
            Message = Status.Successful.ToString(),
            Code = "200"
        };
        var error = new ServiceError
        {
            Message = message
        };
        apiResp.Error = error;

        return apiResp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public static ServiceResponse SuccessResponse()
    {
        var apiResp = new ServiceResponse
        {
            Data = null,
            IsSuccess = true,
            Reference = null,
            Message = Status.Successful.ToString(),
            Code = "200"
        };
        var error = new ServiceError
        {
            Message = null
        };
        apiResp.Error = error;
        return apiResp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <param name="referenceId"></param>
    /// <returns></returns>
    public static ServiceResponse PendingResponse(string? message, object data, string referenceId = "")
    {
        var apiResp = new ServiceResponse
        {
            IsSuccess = true,
            Data = data,
            Reference = referenceId,
            Message = Status.Pending.ToString(),
            Code = "200"
        };
        var error = new ServiceError
        {
            Message = message
        };
        apiResp.Error = error;

        return apiResp;
    }
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="T"></typeparam>
public static class ReturnedServiceResponse<T> //where T : class?
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ServiceResponse<T> ModelStateResponse(string message, T data)
    {
        var apiResp = new ServiceResponse<T>
        {
            Data = data,
            IsSuccess = false,
            Message = Status.Unsuccessful.ToString(),
            Code = ResponseCodes.UNSUCCESSFUL
        };
        var error = new ServiceError
        {
            Message = message
        };
        apiResp.Error = error;
        return apiResp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    public static ServiceResponse<T> ErrorResponse(string? message, T? data, string? code = null)
    {
        var apiResp = new ServiceResponse<T>
        {
            Data = data,
            IsSuccess = false,
            Message = Status.Unsuccessful.ToString(),
            Code = ResponseCodes.UNSUCCESSFUL
        };
        var error = new ServiceError
        {
            Message = message,
            Code = code ?? ResponseCodes.UNSUCCESSFUL
        };
        apiResp.Error = error;
        return apiResp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    public static ServiceResponse<T> ErrorResponse(string? errorCode = null)
    {
        var apiResp = new ServiceResponse<T>
        {
            Data = default,
            IsSuccess = false,
            Message = Status.Unsuccessful.ToString(),
            Code = ResponseCodes.UNSUCCESSFUL
        };
        var error = new ServiceError
        {
            Message = null,
            Code = errorCode
        };
        apiResp.Error = error;
        return apiResp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ServiceResponse<T> ErrorResponse(string message, T? data)
    {
        var apiResp = new ServiceResponse<T>
        {
            Data = data,
            IsSuccess = false,
            Message = Status.Unsuccessful.ToString(),
            Code = ResponseCodes.UNSUCCESSFUL
        };
        var error = new ServiceError
        {
            Message = message
        };
        apiResp.Error = error;
        return apiResp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <param name="referenceId"></param>
    /// <returns></returns>
    public static ServiceResponse<T> SuccessResponse(string? message, T? data, string referenceId = "")
    {
        var apiResp = new ServiceResponse<T>
        {
            Data = data,
            IsSuccess = true,
            Reference = referenceId,
            Message = Status.Successful.ToString(),
            Code = ResponseCodes.SUCCESSFUL
        };
        var error = new ServiceError
        {
            Message = message
        };
        apiResp.Error = error;
        return apiResp;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static ServiceResponse<T> SuccessResponse(T? data)
    {
        var apiResp = new ServiceResponse<T>
        {
            Data = data,
            IsSuccess = true,
            Message = Status.Successful.ToString(),
            Code = ResponseCodes.SUCCESSFUL
        };
        var error = new ServiceError();
        apiResp.Error = error;
        return apiResp;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    /// <param name="referenceId"></param>
    /// <returns></returns>
    public static ServiceResponse<T> PendingResponse(string? message, T? data, string referenceId = "")
    {
        var apiResp = new ServiceResponse<T>
        {
            IsSuccess = true,
            Data = data,
            Reference = referenceId,
            Message = Status.Pending.ToString(),
            Code = ResponseCodes.SUCCESSFUL
        };
        var error = new ServiceError
        {
            Message = message
        };
        apiResp.Error = error;
        return apiResp;
    }
}