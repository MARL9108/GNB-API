using GNB_Data.Data;
using GNB_Data.Response;
using GNB_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Test.MockData
{
    public class RateMockData
    {
        public static RateResponseDTO GetRateList()
        {
            return new RateResponseDTO()
            {
                ConversionRates = new List<RateDTO>()
                {
                    new RateDTO()
                    {
                        From = "EUR",
                        To = "USD",
                        Rate = 1.359m
                    },
                    new RateDTO()
                    {
                        From = "CAD",
                        To = "EUR",
                        Rate = 0.732m
                    },
                    new RateDTO()
                    {
                        From = "USD",
                        To = "EUR",
                        Rate = 0.736m
                    },
                    new RateDTO()
                    {
                        From = "EUR",
                        To = "CAD",
                        Rate = 1.366m
                    }
                }
            };
        }

        public static RateResponseDTO GetEmptyRates() {
            return new RateResponseDTO();
        }
    }
}
