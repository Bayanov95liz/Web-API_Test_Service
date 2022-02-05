using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_API_Test_Service.Model;

namespace Web_API_Test_Service.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelController : Controller
    {
        private readonly IParcelRepository _repository;
        private readonly IMemoryCache _memoryCache;

        public ParcelController(IParcelRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IEnumerable<Parcel> Get()
        {
            return GetCacheParcels();
        }

        [HttpGet("{id:int}/id")]
        public Parcel Get(int id)
        {
            Parcel parcel = GetCacheParcels().FirstOrDefault(parcel => parcel.ID == id);
            return parcel;
        }

        [HttpPost]
        public Parcel Create(Parcel parcel)
        {
            if (ModelState.IsValid)
            {
                _repository.Create(parcel);
                _repository.Save();
            }
            return parcel;
        }

        [HttpPut]
        public Parcel Update(Parcel parcel)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(parcel);
                _repository.Save();
            }
            return parcel;
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }

        private IEnumerable<Parcel> GetCacheParcels()
        {
            const string cachName = "Parcels";

            if (_memoryCache.TryGetValue(cachName, out IEnumerable<Parcel> parcels))
            {
                return parcels;
            }
            else
            {
                parcels = _repository.Get();
                var cacheOprions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddMinutes(10)
                };

                _memoryCache.Set(cachName, parcels, cacheOprions);

                return parcels;
            }
        }

    }
}
