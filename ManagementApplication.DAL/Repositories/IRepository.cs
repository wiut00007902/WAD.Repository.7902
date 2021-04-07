using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementApplication.DAL.Repositories
{
    public interface IRepository<T> where T: class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        bool Exists(int id);
    }
}
