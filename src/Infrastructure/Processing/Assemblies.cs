using System.Reflection;
using Application.Orders.PlaceCustomerOrder;

namespace Infrastructure.Processing
{
    internal static class Assemblies
    {
        public static readonly Assembly Application = typeof(PlaceCustomerOrderCommand).Assembly;
    }
}