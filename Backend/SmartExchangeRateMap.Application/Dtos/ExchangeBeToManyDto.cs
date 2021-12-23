using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartExchangeRateMap.Application.Dtos
{
    public class ExchangeBeToManyDto
    {
        public string BaseUnit { get; set; }
        public DateTime LastUpdate { get; set; }
        public List<WorldUnits> Others { get; set; }
        public class WorldUnits
        {
            public string CountryCode { get; set; }
            public string CountryName { get; set; }
            public double CalculatedPrice { get; set; }
        }
    }

}
