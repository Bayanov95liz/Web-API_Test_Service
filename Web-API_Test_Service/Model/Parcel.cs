using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_Test_Service.Model
{
    [Table("Посылка")]
    public class Parcel
    {
        public int ID { get; set; }
        [Column("Улица")]
        public string Title { get; set; }
        public Address Address { get; set; }
    }
}
