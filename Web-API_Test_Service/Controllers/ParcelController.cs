using Microsoft.AspNetCore.Http;
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
        #region private readonly
        private readonly IParcelRepository _repository;
        private readonly IMemoryCache _memoryCache;
        #endregion

        #region Constructor
        public ParcelController(IParcelRepository repository, IMemoryCache memoryCache)
        {
            _repository = repository;
            _memoryCache = memoryCache;
        }
        #endregion

        #region public methods
        /// <summary>
        /// Возвращает информацию обо всех поссылках.
        /// </summary>
        /// <returns>Список всех посылок</returns>
        [HttpGet]
        public IEnumerable<Parcel> Get()
        {
            return GetCacheParcels();
        }

        /// <summary>
        /// Возвращает определенную посылку по уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор посылки</param>
        /// <response code="201">Возвращает найденную посылку</response>
        /// <response code="400">Если посылка не найдена возвращает null</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// <param name="parcel">Модель посылки</param>
        /// <response code="201">Возвращает вновь созданную модель посылки</response>
        /// <response code="400">Если элемент null</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        /// <param name="parcel">Модель посылки</param>
        /// <returns>Структура обновленой посылки</returns>
        /// <response code="201">Возвращает вновь обновленую модель посылки</response>
        /// <response code="400">Если элемент null</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Parcel Update(Parcel parcel)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(parcel);
                _repository.Save();
            }
            return parcel;
        }

        #endregion

        #region override
        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
        #endregion

        #region private methods
        /// <summary>
        /// Кеширует информацию обо всех посылках.
        /// </summary>
        /// <returns>Список всех посылок</returns>
        private IEnumerable<Parcel> GetCacheParcels()
        {
            const string cachName = "Parcels";

            if (_memoryCache.TryGetValue(cachName, out IEnumerable<Parcel> parcels))
            {
                return parcels;
            }
            else
            {
                parcels = _repository.GetParcels();
                var cacheOprions = new MemoryCacheEntryOptions()
                {
                    Priority = CacheItemPriority.High,
                    AbsoluteExpiration = DateTime.Now.AddMinutes(10)
                };

                _memoryCache.Set(cachName, parcels, cacheOprions);

                return parcels;
            }
        }
        #endregion

    }
}
