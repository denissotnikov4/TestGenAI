using System.Collections.Generic;

namespace Domain.ForeignExchange
{
    public interface IForeignExchange
    {
        List<ConversionRate> GetConversionRates();
    }
}