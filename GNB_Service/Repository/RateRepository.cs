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
    public class RateRepository : GNBRepository<Rate>, IRateRepository
    {
        public RateRepository(GNBContext context): base(context) { }

        public async Task AddRangeRates(IEnumerable<Rate> rates)
        {
            await AddRange(rates);
        }

        public async Task DeleteRangeRates(IEnumerable<Rate> rates)
        {
            await DeleteRange(rates);
        }

        public async Task<IEnumerable<Rate>> GetAllRates()
        {
            return await GetAll();
        }
    }
}
