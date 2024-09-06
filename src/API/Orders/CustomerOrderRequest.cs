using System.Collections.Generic;
using Application.Orders;

namespace API.Orders
{
    public class CustomerOrderRequest
    {
        public List<ProductDto> Products { get; set; }

        public string Currency { get; set; }
    }
}