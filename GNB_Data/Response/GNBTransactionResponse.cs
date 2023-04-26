using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Data.Response
{
    public class GNBTransactionResponse: TransactionResponseDTO
    {
        public decimal? totalAmount { get; set; }
    }
}
