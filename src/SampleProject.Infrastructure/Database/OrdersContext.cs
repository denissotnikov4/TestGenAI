using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Customers;
using SampleProject.Domain.Payments;
using SampleProject.Domain.Products;
using SampleProject.Infrastructure.Processing.InternalCommands;
using SampleProject.Infrastructure.Processing.Outbox;

namespace SampleProject.Infrastructure.Database
{
    /*public class OrdersContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OutboxMessage> OutboxMessages { get; set; }

        public DbSet<InternalCommand> InternalCommands { get; set; }

        public DbSet<Payment> Payments { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost; Port=5432; Database=testgen; User ID=postgres; Password=12345; Pooling=true");
        }

        public OrdersContext() : base()
        {
            
        }
        
        public OrdersContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customerEntity = modelBuilder.Entity<Customer>();

            customerEntity.ToTable("Customers");

            customerEntity.HasKey(b => b.Id);

            customerEntity.Property("_email").HasColumnName("Email");
            customerEntity.Property("_name").HasColumnName("Name");
            customerEntity.Property("_welcomeEmailWasSent").HasColumnName("WelcomeEmailWasSent");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrdersContext).Assembly);
        }
    }*/
}
