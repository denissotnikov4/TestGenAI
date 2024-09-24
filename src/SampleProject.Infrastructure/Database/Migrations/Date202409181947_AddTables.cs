using System.Data;
using FluentMigrator;
using SampleProject.Domain.RefreshTokens;
using SampleProject.Domain.Users;

namespace SampleProject.Infrastructure.Database.Migrations;

[Migration(202409181947)]
public class Date202409181947_AddTables : Migration
{
    private const string ForeignKeyRefreshTokenToUser = "FK_RefreshToken_User";
    
    private readonly string _userTableName = nameof(User).ToLower();
    private readonly string _refreshTokenTableName = nameof(RefreshToken).ToLower();
    
    public override void Up()
    {
        if (!Schema.Table(_userTableName).Exists())
        {
            Create.Table(_userTableName)
                .WithColumn(nameof(User.Id)).AsGuid().PrimaryKey().NotNullable().WithDefault(SystemMethods.NewGuid)
                .WithColumn(nameof(User.Username)).AsString().NotNullable()
                .WithColumn(nameof(User.Role)).AsInt32().NotNullable().WithDefaultValue((int)Role.Default)
                .WithColumn(nameof(User.PasswordHash)).AsString().NotNullable()
                .WithColumn(nameof(User.Email)).AsString().Nullable()
                .WithColumn(nameof(User.CreatedAt)).AsDateTime().NotNullable();
        }

        if (!Schema.Table(_refreshTokenTableName).Exists())
        {
            Create.Table(_refreshTokenTableName)
                .WithColumn(nameof(RefreshToken.Id)).AsGuid().PrimaryKey().NotNullable().WithDefault(SystemMethods.NewGuid)
                .WithColumn(nameof(RefreshToken.UserId)).AsGuid().Nullable()
                .WithColumn(nameof(RefreshToken.Token)).AsString().NotNullable()
                .WithColumn(nameof(RefreshToken.CreatedAt)).AsDateTime().NotNullable()
                .WithColumn(nameof(RefreshToken.ExpiresAt)).AsDateTime().NotNullable()
                .WithColumn(nameof(RefreshToken.RevokedAt)).AsDateTime().Nullable();

            Create.ForeignKey(ForeignKeyRefreshTokenToUser)
                .FromTable(_refreshTokenTableName).ForeignColumn(nameof(RefreshToken.UserId))
                .ToTable(_userTableName).PrimaryColumn(nameof(User.Id)).OnDeleteOrUpdate(Rule.Cascade);
        }
    }

    public override void Down()
    {
        if (Schema.Table(_userTableName).Exists())
        {
            Delete.Table(_userTableName);
        }

        if (Schema.Table(_refreshTokenTableName).Exists())
        {
            Delete.Table(_refreshTokenTableName);
        }
    }
}