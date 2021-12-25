using RestSharp;
using SmartExchangeRateMap.Application.Dtos;
using SmartExchangeRateMap.Application.OurService.Interface;
using SmartExchangeRateMap.Application.OurService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartExchangeRateMap.Application.OurService
{
   
    public class ExchangeRateApiComService : IExchangeCurrencyOurService<ExchangeRateApiResult>
    {
        const string BASE_URL = "https://v6.exchangerate-api.com/v6/";
        const string API_KEY = "5bcd9dbe850716d5670760fe";

        /// <summary>
        /// latest status
        /// </summary>
        /// <param name="BaseUnit">USD</param>
        /// <returns></returns>
        public async Task<(ExchangeOneToManyDto, HttpStatusCode)> ExchangeOneToManyAsync(string BaseUnit)
        {
            var url = $"{BASE_URL}/{API_KEY}/latest/{BaseUnit.ToUpper()}";
            var client = new RestClient(url);
            client.Timeout = 50000;
            var request = new RestRequest(Method.GET);
            IRestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful == false)
            {
                return (null, response.StatusCode);
            }
            ExchangeRateApiResult result = JsonSerializer.Deserialize<ExchangeRateApiResult>(response.Content);
            ExchangeOneToManyDto mappedResult = MappingExchangeOneToMany(result);


            return (mappedResult, response.StatusCode);
        }
        public ExchangeOneToManyDto MappingExchangeOneToMany(ExchangeRateApiResult result)
        {
            try
            {
                List<ExchangeOneToManyDto.WorldUnit> worlUnits = new();
                PropertyInfo[] getProperties = result.conversion_rates.GetType().GetProperties();
                foreach (var property in getProperties)
                {
                    var value = property.GetValue(property);
                    worlUnits.Add(new()
                    {
                        CountryCode = property.Name,
                        CalculatedPrice = (double)value,
                    });
                }
                return new ExchangeOneToManyDto
                {
                    BaseUnit = result.base_code,
                    Others = worlUnits
                };

            }
            catch (Exception ex)
            {

                return null;
            }
        }

    }
    
}
