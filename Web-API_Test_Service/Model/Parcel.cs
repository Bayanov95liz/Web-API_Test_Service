using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API_Test_Service.Model
{
    public class Parcel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public Address Address { get; set; }
    }
}
