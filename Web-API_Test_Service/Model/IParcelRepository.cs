using System;
using System.Collections.Generic;

namespace Web_API_Test_Service.Model
{
    /// <summary>
    /// Репозиторий для работы с посылками
    /// </summary>
    public interface IParcelRepository : IDisposable 
    {
        /// <summary>
        /// Возвращает информацию обо всех поссылках.
        /// </summary>
        /// <returns>Список всех посылок</returns>
        IEnumerable<Parcel> GetParcels();
        /// <summary>
        /// Возвращает определенную посылку по уникальному идентификатору.
        /// </summary>
        /// <param name="id">Уникальный идентификатор посылки</param>
        /// <returns>Струкрура посылки</returns>
        Parcel GetParcel(int id);
        /// <summary>
        /// Создает новую посылку
        /// </summary>
        /// <param name="item">Структура добавленой посылки</param>
        void Create(Parcel item);
        /// <summary>
        /// Обновляет информацию существующей посылки
        /// </summary>
        /// <param name="item">Модель посылки</param>
        void Update(Parcel item);
        /// <summary>
        /// Обновляет информацию по уникальному идентификатору
        /// </summary>
        /// <param name="id">Уникальный идентификатор посылки</param>
        void Delete(int id); 
        /// <summary>
        /// Сохраняет изменения в базу данных
        /// </summary>
        void Save(); 
    }
}
