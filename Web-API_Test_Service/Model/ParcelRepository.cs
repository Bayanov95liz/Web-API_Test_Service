using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Web_API_Test_Service.Model
{
    public class ParcelRepository : IParcelRepository
    {
        private ParcelContext _context;

        public ParcelRepository(ParcelContext context)
        {
            _context = context;
        }

        public IEnumerable<Parcel> GetParcels()
        {
            return _context.Parcels.ToList();
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

        public Parcel GetParcel(int id)
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

        private bool _disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
