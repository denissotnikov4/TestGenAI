using Domain.SharedKernel;

namespace Domain.Products
{
    public class ProductPrice
    {
        public MoneyValue Value { get; private set; }

        private ProductPrice()
        {
            
        }
    }
}