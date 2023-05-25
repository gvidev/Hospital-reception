using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class DoctorVM
    {
        public int Id { get; set; }

        [StringLength(20)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(20)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [StringLength(20)]
        [Required]
        public string Specialization { get; set; }

        [StringLength(10)]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int Hospital_Id { get; set; }

        public List<Data.Entities.Patient> Patients {get;set;}

        public DoctorVM() { }

        public DoctorVM(DoctorDTO doctorDTO)
        {
            Id = doctorDTO.Id;
            FirstName = doctorDTO.FirstName;
            LastName = doctorDTO.LastName;
            Age = doctorDTO.Age;
            Specialization = doctorDTO.Specialization;
            PhoneNumber = doctorDTO.PhoneNumber;
            Hospital_Id = doctorDTO.Hospital_Id;
            Patients = doctorDTO.Patients;
        }
    }
}