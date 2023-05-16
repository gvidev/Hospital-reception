using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Patient : BaseEntity
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsUrgent { get; set; }
        public DateTime DateOfAdmission { get; set; }
        public DateTime? DateOfDischarge { get; set; }

        public int Doctor_Id { get; set; }
        public Doctor Doctor { get; set; }
    }
}
