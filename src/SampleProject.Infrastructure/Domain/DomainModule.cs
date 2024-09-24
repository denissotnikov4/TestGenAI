using Autofac;
using SampleProject.Application.Customers.DomainServices;
using SampleProject.Application.Users.DomainServices;
using SampleProject.Domain.Customers;
using SampleProject.Domain.ForeignExchange;
using SampleProject.Domain.Users;
using SampleProject.Infrastructure.Domain.ForeignExchanges;

namespace SampleProject.Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerUniquenessChecker>()
                .As<ICustomerUniquenessChecker>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UsernameUniquenessChecker>()
                .As<IUsernameUniquenessChecker>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ForeignExchange>()
                .As<IForeignExchange>()
                .InstancePerLifetimeScope();
        }
    }
}