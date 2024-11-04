using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Chats;

namespace SampleProject.Infrastructure.Database;

public class ApplicationContext : IdentityDbContext<IdentityUser>
{
    public ApplicationContext(DbContextOptions options) : base(options) { }
    
    public DbSet<Chat> Chats { get; set; }
}