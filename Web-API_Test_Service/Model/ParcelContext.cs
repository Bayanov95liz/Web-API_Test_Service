using Microsoft.EntityFrameworkCore;

namespace Web_API_Test_Service.Model
{
    public class ParcelContext : DbContext
    {
        public ParcelContext(DbContextOptions<ParcelContext> options) : base(options) { }

        public DbSet<Parcel> Parcels { get; set; }
    }
}
