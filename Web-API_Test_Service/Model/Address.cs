using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_Test_Service.Model
{
    [Table("Адрес")]
    public class Address
    {
        public int ID { get; set; }
        [Required]
        [Column("Город")]
        public string City { get; set; }
        [Required]
        [Column("Улица")]
        public string Street { get; set; }
        [Required]
        [Column("Номер дома")]
        public string House { get; set; }
    }
}
