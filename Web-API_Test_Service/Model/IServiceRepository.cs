using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_Test_Service.Model
{
    public interface IServiceRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> Get();
        T Get(int id);
        void Create(T item);
        void Update(T item); 
        void Delete(int id); 
        void Save(); 
    }
}
