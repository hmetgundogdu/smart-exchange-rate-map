using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartExchangeRateMap.Application.Dtos
{
    public class ExchangeOneToManyDto
    {
        public string BaseUnit { get; set; }
        public List<WorldUnit> Others { get; set; }
        public class WorldUnit
        {
            public string CountryCode { get; set; }
            public string CountryName { get; set; }
            public double CalculatedPrice { get; set; }
        }
    }

}
