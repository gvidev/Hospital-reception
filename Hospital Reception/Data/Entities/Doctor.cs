using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Doctor : BaseEntity
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }
        public int YearsOfExperiance { get; set; }
        public double MonthSalary { get; set; }

        public int Hospital_Id { get; set; }
        public Hospital Hospital { get; set; }


    }
}
