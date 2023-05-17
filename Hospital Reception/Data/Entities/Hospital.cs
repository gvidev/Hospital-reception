using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Hospital : BaseEntity
    {

        public string HospitalName { get; set; }
        public string Address { get; set; }
        public int AddressNumber { get; set; }
        public string City { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public int Floors { get; set; }
        public int Capacity { get; set; }

    }
}
