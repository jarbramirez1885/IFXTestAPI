using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace school.ApplicationCore.Interfaces.Repositories
{
    public interface IAsyncRepository<T>
    {
        Task<List<T>> ListAllAsync();
        Task<T> GetByIdAsync(long id);
    }
}
