using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Patient : BaseEntity
    {
        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        public int Age { get; set; }
        public char Gender { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public bool IsUrgent { get; set; }
        public DateTime? AppointmentDate { get; set; }

        public int Doctor_Id { get; set; }
        public Doctor Doctor { get; set; }
    }
}
