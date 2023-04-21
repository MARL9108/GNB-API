using GNB_Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GNB_Repository.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entityRange);
        Task Update(T entity);
        Task Delete(int id);
        Task DeleteRange(IEnumerable<T> range);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
    }
}
