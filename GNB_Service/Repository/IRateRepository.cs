using GNB_Repository.Base;
using GNB_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Service.Repository
{
    public interface IRateRepository: IBaseRepository<Rate>
    {
        Task<IEnumerable<Rate>> GetAllRates();
        Task DeleteRangeRates(IEnumerable<Rate> rates);
        Task AddRangeRates(IEnumerable<Rate> rates);
    }
}
