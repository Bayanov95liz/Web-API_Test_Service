using System.ComponentModel.DataAnnotations;

namespace Web_API_Test_Service.Model
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int House { get; set; }
    }
}
