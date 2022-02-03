using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_Test_Service.Model
{
    public class ServiceContext : DbContext
    {
        public ServiceContext() : base("ServiceContext")
        { 
            
        }

        public DbSet<Parcel> Parcels { get; set; }
    }
}
