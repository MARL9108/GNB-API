using GNB_Data.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Test.MockData.Request
{
    public class TransactionRequestMockData
    {
        public TransactionRequestMockData()
        {
            transactionRequest = new TransactionRequest() { Sku = "T2006" };
        }
        public TransactionRequest transactionRequest { get; set; }
    }
}
