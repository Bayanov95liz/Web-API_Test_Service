using System.ComponentModel.DataAnnotations;

namespace Web_API_Test_Service.Model
{
    /// <summary>
    /// Почтовый адрес
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Уникальный идентфикатор
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Город
        /// </summary>
        [Required]
        public string City { get; set; }
        /// <summary>
        /// Улица
        /// </summary>
        [Required]
        public string Street { get; set; }
        /// <summary>
        /// Номер дома
        /// </summary>
        [Required]
        public int House { get; set; }
    }
}
