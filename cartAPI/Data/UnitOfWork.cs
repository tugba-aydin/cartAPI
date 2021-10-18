using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cartAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDBContext myDBContext;
        public UnitOfWork(MyDBContext _myDBContext)
        {
            myDBContext = _myDBContext;
        }
        public void Dispose()
        {
            myDBContext.Dispose();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            return new Repository<T>(myDBContext);
        }

        public int SaveChanges()
        {
            return myDBContext.SaveChanges();
        }
    }
}
