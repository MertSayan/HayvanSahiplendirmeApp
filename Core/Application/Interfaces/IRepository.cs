using Application.Features.MediatR.Users.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        //Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter); 
        //aşağıdaki metot üstteki metodun daha gelişmişidir. aşağıdaki metot başka tabloları da include edebilmemizi sağlar.
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes);

        //toplu ekleme yapmak için bu entity e özgü servis-interface de kullanılabilir.
        //Task CreateRangeAsync(IEnumerable<T> entities);


    }
}
