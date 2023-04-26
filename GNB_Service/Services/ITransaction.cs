using GNB_Data.Data;
using GNB_Data.Request;
using GNB_Data.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Service.Services
{
    public interface ITransaction
    {
        Task<TransactionResponseDTO> GetAllTransactions();
        GNBTransactionResponse GetTransaction(TransactionRequest transactionRequest);
        GNBTransactionResponse GetTransactionBySku(string Sku);
    }
}
