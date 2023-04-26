using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Data.Data
{
    public class TransactionDTO
    {
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
