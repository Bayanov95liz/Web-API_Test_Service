using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using Web_API_Test_Service.Model;

namespace Web_API_Test_Service.Controllers
{
    /// <summary>
    /// Контроллер для работы с посылками
    /// </summary>
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

        /// <summary>
        /// Получает информацию обо всех посылках
        /// </summary>
        /// <returns>Возвращает информацию обо всех поссылках.</returns>
        [HttpGet]
        public IEnumerable<Parcel> Get()
        {
            return GetCacheParcels();
        }

        /// <summary>
        /// Получает определенную посылку по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public Parcel Get(int id)
        {
            Parcel parcel = GetCacheParcels().FirstOrDefault(parcel => parcel.ID == id);
            return parcel;
        }

        /// <summary>
        /// Создает новую посылку
        /// </summary>
        /// <param name="parcel">Структура посылки</param>
        /// <returns>Структура добавленой посылки</returns>
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

        /// <summary>
        /// Обновляет информацию существующей посылки
        /// </summary>
        /// <param name="parcel">Структура посылки</param>
        /// <returns>Структура обновленой посылки</returns>
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
