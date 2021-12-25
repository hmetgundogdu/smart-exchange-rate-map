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
    public class FreeCurrencyService : IExchangeCurrencyOurService<FreeCurrencyApiResult>
    {
        const string BASE_URL = "https://freecurrencyapi.net/api/v2";
        const string API_KEY = "0cdc2f90-6599-11ec-b7d8-ef5751521d13";

        /// <summary>
        /// latest status
        /// </summary>
        /// <param name="BaseUnit">USD</param>
        /// <returns></returns>
        public async Task<(ExchangeOneToManyDto, HttpStatusCode)> ExchangeOneToManyAsync(string BaseUnit)
        {
            var url = $"{BASE_URL}/latest";
            var client = new RestClient(url);
            client.Timeout = 50000;
            var request = new RestRequest(Method.GET);
            request.AddQueryParameter("api_key", API_KEY);
            request.AddQueryParameter("base_currency", BaseUnit);
            IRestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessful == false)
            {
                return (null, response.StatusCode);
            }
            FreeCurrencyApiResult result = JsonSerializer.Deserialize<FreeCurrencyApiResult>(response.Content);
            ExchangeOneToManyDto mappedResult = MappingExchangeOneToMany(result);


            return (mappedResult, response.StatusCode);
        }

        public ExchangeOneToManyDto MappingExchangeOneToMany(FreeCurrencyApiResult result)
        {
            try
            {
                List<ExchangeOneToManyDto.WorldUnit> worlUnits = new();
                PropertyInfo[] getProperties = result.data.GetType().GetProperties();
                foreach (var property in getProperties)
                {
                    var value = property.GetValue(result.data, null);
                    worlUnits.Add(new()
                    {
                        CountryCode = property.Name,
                        CalculatedPrice= (double)value,
                    });
                }
                return new ExchangeOneToManyDto
                {
                    BaseUnit = result.query?.base_currency,
                    Others=worlUnits
                };

            }
            catch(Exception ex)
            {

                return null;
            }
        }

    }
}
