using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Hospital : BaseEntity
    {
        [StringLength(50)]
        public string HospitalName { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        public int AddressNumber { get; set; }

        [StringLength(20)]
        public string City { get; set; }

        [StringLength(10)]
        public string ContactNumber { get; set; }

        [StringLength(60)]
        public string Email { get; set; }

        public int? Floors { get; set; }
        public int? Capacity { get; set; }

    }
}
