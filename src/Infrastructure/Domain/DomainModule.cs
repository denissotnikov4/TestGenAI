using Autofac;
using Application.Customers.DomainServices;
using Domain.Customers;
using Domain.ForeignExchange;
using Infrastructure.Domain.ForeignExchanges;

namespace Infrastructure.Domain
{
    public class DomainModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerUniquenessChecker>()
                .As<ICustomerUniquenessChecker>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ForeignExchange>()
                .As<IForeignExchange>()
                .InstancePerLifetimeScope();
        }
    }
}