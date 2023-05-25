using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.ViewModels
{
    public class HospitalVM
    {
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string HospitalName { get; set; }

        [StringLength(50)]
        [Required]
        public string Address { get; set; }

        [Required]
        public int AddressNumber { get; set; }

        [StringLength(20)]
        [Required]
        public string City { get; set; }

        [StringLength(10)]
        [Required]
        public string ContactNumber { get; set; }

        [StringLength(60)]
        [Required]
        public string Email { get; set; }

        public List<Data.Entities.Doctor> Doctors { get; set; }

        public HospitalVM() { }

        public HospitalVM(HospitalDTO hospitalDTO)
        {
            Id = hospitalDTO.Id;
            HospitalName = hospitalDTO.HospitalName;
            Address = hospitalDTO.Address;
            AddressNumber = hospitalDTO.AddressNumber;
            City = hospitalDTO.City;
            ContactNumber = hospitalDTO.ContactNumber;
            Email = hospitalDTO.Email;
            Doctors = hospitalDTO.Doctors;
        }

    }
}