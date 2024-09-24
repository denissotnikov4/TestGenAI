using SampleProject.Application.Exceptions.Base;

namespace SampleProject.Application.Exceptions;

public class NonUniqueUsernameException : BaseCustomException
{
    public NonUniqueUsernameException(string message) : base(message)
    {
    }
}