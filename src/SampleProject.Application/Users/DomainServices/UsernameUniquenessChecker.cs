using System.Threading.Tasks;
using Dapper;
using SampleProject.Application.Configuration.Data;
using SampleProject.Domain.Users;

namespace SampleProject.Application.Users.DomainServices;

public class UsernameUniquenessChecker : IUsernameUniquenessChecker
{
    private readonly ISqlConnectionFactory _sqlConnectionFactory;

    public UsernameUniquenessChecker(ISqlConnectionFactory sqlConnectionFactory)
    {
        _sqlConnectionFactory = sqlConnectionFactory;
    }

    public bool IsUnique(string username)
    {
        var connection = _sqlConnectionFactory.GetOpenConnection();

        var sql = $"SELECT EXISTS " +
                  $"(SELECT 1 "  +
                  $"FROM \"{nameof(User).ToLower()}\" AS \"Users\" " +
                  $"WHERE \"Users\".\"{nameof(User.Username)}\" = @Username)";

        var isUnique = connection.ExecuteScalar(sql, new { Username = username });

        return (bool)isUnique;
    }
}