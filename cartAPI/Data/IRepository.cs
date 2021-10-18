using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cartAPI.Data
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void SaveAll();
        void Delete(int id);
        List<T> GetAll();
        T GetById(int id);
        void Update(T entity);
    }
}
