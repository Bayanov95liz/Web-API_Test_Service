using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Web_API_Test_Service.Model
{
    public class ParcelRepository : IServiceRepository<Parcel>
    {
        private ServiceContext _context;

        public ParcelRepository(ServiceContext context)
        {
            _context = context;
        }

        public void Create(Parcel parcel)
        {
            _context.Parcels.Add(parcel);
        }

        public void Delete(int id)
        {
            Parcel parcel = _context.Parcels.Find(id);
            if (parcel != null)
            {
                _context.Parcels.Remove(parcel);
            }
                
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Parcel Get(int id)
        {
            return _context.Parcels.Find(id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Parcel parcel)
        {
            _context.Entry(parcel).State = EntityState.Modified;
        }

        public IEnumerable<Parcel> Get()
        {
           return _context.Parcels;
        }
    }
}
