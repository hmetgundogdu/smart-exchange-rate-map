using SmartExchangeRateMap.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartExchangeRateMap.Application.OurService.Interface
{
    
    public interface IExchangeCurrencyOurService<T>
    {
   

        Task<(ExchangeOneToManyDto, HttpStatusCode)> ExchangeOneToManyAsync(string BaseUnit);
        ExchangeOneToManyDto MappingExchangeOneToMany(T result);
    }
}
