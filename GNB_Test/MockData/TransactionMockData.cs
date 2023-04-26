using GNB_Data.Data;
using GNB_Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Test.MockData
{
    public class TransactionMockData
    {
        public static TransactionResponseDTO GetTransacionList()
        {
            return new TransactionResponseDTO()
            {
                Transactions = new List<TransactionDTO>()
                {
                    new TransactionDTO()
                    {
                        Sku = "T2006",
                        Amount = 10.00m,
                        Currency = "USD"
                    },
                    new TransactionDTO()
                    {
                        Sku = "M2007",
                        Amount = 34.57m,
                        Currency = "CAD"
                    },
                    new TransactionDTO()
                    {
                        Sku = "R2008",
                        Amount = 17.95m,
                        Currency = "USD"
                    },
                    new TransactionDTO()
                    {
                        Sku = "T2006",
                        Amount = 7.63m,
                        Currency = "EUR"
                    },
                    new TransactionDTO()
                    {
                        Sku = "B2009",
                        Amount = 21.23m,
                        Currency = "USD"
                    }
                }

            };
        }
        public static TransactionResponseDTO GetEmptyTransacion()
        {
            return new TransactionResponseDTO();
        }
    }
}
