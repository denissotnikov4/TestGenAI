using SampleProject.Domain.SeedWork;

namespace SampleProject.Domain.Users.Rules
{
    public class UsernameMustBeUniqueRule : IBusinessRule
    {
        private readonly string _username;

        private readonly IUsernameUniquenessChecker _usernameUniquenessChecker;

        public UsernameMustBeUniqueRule(string username, IUsernameUniquenessChecker usernameUniquenessChecker)
        {
            _username = username;
            _usernameUniquenessChecker = usernameUniquenessChecker;
        }

        public bool IsBroken() => _usernameUniquenessChecker.IsUnique(_username);

        public string Message => "User with this username already exists.";
    }
}