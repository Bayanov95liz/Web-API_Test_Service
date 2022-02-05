using System.ComponentModel.DataAnnotations;

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
