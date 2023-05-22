using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class PatientVM
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

        [StringLength(10)]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int Doctor_Id { get; set; }

        public PatientVM() { }

        public PatientVM(PatientVM patientDTO)
        {
            Id = patientDTO.Id;
            FirstName = patientDTO.FirstName;
            LastName = patientDTO.LastName;
            Age = patientDTO.Age;
            PhoneNumber = patientDTO.PhoneNumber;
            Doctor_Id = patientDTO.Doctor_Id;
        }

    }
}