using GNB_Repository.Base;
using GNB_Repository.Context;
using GNB_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Service.Repository
{
    public class TransactionRepository : GNBRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(GNBContext gNBContext): base(gNBContext) { }

        public async Task AddTransactionsRates(IEnumerable<Transaction> transactions)
        {
            await AddRange(transactions);
        }

        public async Task DeleteTransactionsRates(IEnumerable<Transaction> transactions)
        {
            await DeleteRange(transactions);
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactions()
        {
            return await GetAll();
        }
    }
}
