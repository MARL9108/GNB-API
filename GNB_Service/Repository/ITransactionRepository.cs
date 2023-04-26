using GNB_Repository.Base;
using GNB_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Service.Repository
{
    public interface ITransactionRepository: IBaseRepository<Transaction>
    {
        Task<IEnumerable<Transaction>> GetAllTransactions();
        Task DeleteTransactionsRates(IEnumerable<Transaction> transactions);
        Task AddTransactionsRates(IEnumerable<Transaction> transactions);
    }
}
