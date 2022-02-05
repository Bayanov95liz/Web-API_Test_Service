using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_Test_Service.Model
{
    public interface IParcelRepository : IDisposable 
    {
        IEnumerable<Parcel> Get();
        Parcel Get(int id);
        void Create(Parcel item);
        void Update(Parcel item); 
        void Delete(int id); 
        void Save(); 
    }
}
