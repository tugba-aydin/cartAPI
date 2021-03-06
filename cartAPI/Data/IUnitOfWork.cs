using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cartAPI.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class;
        int SaveChanges();
    }
}
