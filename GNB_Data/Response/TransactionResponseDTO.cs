using GNB_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Data.Response
{
    public class TransactionResponseDTO
    {
        public List<TransactionDTO> Transactions { get; set; }
    }
}
