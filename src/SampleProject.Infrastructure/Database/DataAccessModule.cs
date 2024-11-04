using Autofac;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SampleProject.Application.Configuration.Data;
using SampleProject.Domain.Chats;
using SampleProject.Domain.Customers.Orders;
using SampleProject.Domain.Payments;
using SampleProject.Domain.Products;
using SampleProject.Domain.SeedWork;
using SampleProject.Domain.Users;
using SampleProject.Infrastructure.Domain;
using SampleProject.Infrastructure.Domain.Chats;
using SampleProject.Infrastructure.Domain.Customers;
using SampleProject.Infrastructure.Domain.Payments;
using SampleProject.Infrastructure.Domain.Products;
using SampleProject.Infrastructure.Domain.Users;
using SampleProject.Infrastructure.SeedWork;

namespace SampleProject.Infrastructure.Database
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;

        public DataAccessModule(string databaseConnectionString)
        {
            this._databaseConnectionString = databaseConnectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SqlConnectionFactory>()
                .As<ISqlConnectionFactory>()
                .WithParameter("connectionString", _databaseConnectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();


            builder.RegisterType<CustomerRepository>()
                .As<ICustomerRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>()
                .As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PaymentRepository>()
                .As<IPaymentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ChatRepository>()
                .As<IChatRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StronglyTypedIdValueConverterSelector>()
                .As<IValueConverterSelector>()
                .SingleInstance();

            /*builder
                .Register(c =>
                {
                    var dbContextOptionsBuilder = new DbContextOptionsBuilder<OrdersContext>();
                    dbContextOptionsBuilder.UseNpgsql(_databaseConnectionString);
                    dbContextOptionsBuilder
                        .ReplaceService<IValueConverterSelector, StronglyTypedIdValueConverterSelector>();
                    
                    return new OrdersContext(dbContextOptionsBuilder.Options);
                })
                .AsSelf()
                .As<DbContext>()
                .InstancePerLifetimeScope()*/;
        }
    }
}