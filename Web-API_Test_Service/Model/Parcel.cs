using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_Test_Service.Model
{
    public class Parcel
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
