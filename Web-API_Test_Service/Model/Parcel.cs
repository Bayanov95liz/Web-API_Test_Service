using System.ComponentModel.DataAnnotations;

namespace Web_API_Test_Service.Model
{
    /// <summary>
    /// Посылка
    /// </summary>
    public class Parcel
    {
        /// <summary>
        /// Уникальный идентфикатор
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Информация о посылке
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Адрес посылки
        /// </summary>
        [Required]
        public Address Address { get; set; }
    }
}
