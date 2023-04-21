using GNB_Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Test.MockData.Response
{
    public class TransactionResponseMockData
    {
        public static GNBTransactionResponse GetTransactionBySku(string sku)
        {
            var mockData = TransactionMockData.GetTransacionList();
            var elementsFinded= mockData.Transactions.Find(x => x.Sku.Equals(sku));
            return new GNBTransactionResponse() { Transactions = new List<GNB_Data.Data.TransactionDTO> { elementsFinded } };
        }
        public static GNBTransactionResponse GetTransactionEmpty()
        {
            return new GNBTransactionResponse() { };
        }
    }
}
