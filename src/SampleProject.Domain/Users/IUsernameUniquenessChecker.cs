using System.Threading.Tasks;

namespace SampleProject.Domain.Users
{
    public interface IUsernameUniquenessChecker
    {
        bool IsUnique(string username);
    }
}