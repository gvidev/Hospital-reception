using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.DTOs
{
    public class DoctorDTO
    {
        public int Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string LastName { get; set; }

        public int Age { get; set; }
        public char Gender { get; set; }

        [StringLength(20)]
        public string Specialization { get; set; }

        [StringLength(10)]
        public string PhoneNumber { get; set; }

        public int YearsOfExperiance { get; set; }
        public double MonthSalary { get; set; }

        public int Hospital_Id { get; set; }
        public HospitalDTO Hospital { get; set; }

    }
}
