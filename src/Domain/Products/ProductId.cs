using System;
using Domain.SeedWork;

namespace Domain.Products
{
    public class ProductId : TypedIdValueBase
    {
        public ProductId(Guid value) : base(value)
        {
        }
    }
}