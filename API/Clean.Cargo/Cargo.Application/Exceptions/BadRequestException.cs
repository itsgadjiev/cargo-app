﻿namespace Cargo.Application.Exceptions;

public class BadRequestException : ApplicationException
{
    public string Key { get; set; }
    public string ErrorMessage { get; set; }

    public BadRequestException(string key, string errorMessage) 
        : base(errorMessage)
    {
        Key = key;
        ErrorMessage = errorMessage;
    }

    public BadRequestException(string errorMessage) 
        : base(errorMessage)
    {
        Key = string.Empty;
        ErrorMessage = errorMessage;
    }

}
