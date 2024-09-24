using System;

namespace SampleProject.Application.Exceptions.Base;

public abstract class BaseCustomException : Exception
{
    public int ErrorCode { get; }

    protected BaseCustomException(string message) : base(message)
    {
    }

    protected BaseCustomException(string message, Exception innerException) 
        : base(message, innerException)
    {
    }

    protected BaseCustomException(string message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}