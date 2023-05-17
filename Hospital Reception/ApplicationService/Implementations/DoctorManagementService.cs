using ApplicationService.DTOs;
using Data.Entities;
using Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationService.Implementations
{
    public class DoctorManagementService
    {

        public List<DoctorDTO> Get()
        {
            List<DoctorDTO> doctorsDTO = new List<DoctorDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.DoctorRepository.Get())
                {
                    doctorsDTO.Add(new DoctorDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Age = item.Age,
                        Gender = item.Gender,
                        PhoneNumber = item.PhoneNumber,
                        Hospital = new HospitalDTO
                        {
                            Id = item.Hospital.Id,
                            HospitalName = item.Hospital.HospitalName
                        }
                    });
                }
            }

            return doctorsDTO;
        }

        public DoctorDTO GetById(int id)
        {
            DoctorDTO doctorDTO = new DoctorDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Doctor doctor = unitOfWork.DoctorRepository.GetByID(id);
                if (doctor != null)
                {
                    doctorDTO = new DoctorDTO
                    {
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        Age = doctor.Age,
                        Gender = doctor.Gender,
                        PhoneNumber = doctor.PhoneNumber,
                        Hospital = new HospitalDTO
                        {
                            Id = doctor.Hospital.Id,
                            HospitalName = doctor.Hospital.HospitalName
                        }

                    };

                }
            }
            return doctorDTO;
        }


        public bool Save(DoctorDTO doctorDTO)
        {
            if (doctorDTO.Hospital_Id == 0)
            {
                return false;
            }

            Doctor doctor = new Doctor
            {
                FirstName = doctorDTO.FirstName,
                LastName = doctorDTO.LastName,
                Age = doctorDTO.Age,
                Gender = doctorDTO.Gender,
                PhoneNumber = doctorDTO.PhoneNumber,
                Hospital_Id = doctorDTO.Hospital_Id
            };

            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.DoctorRepository.Insert(doctor);
                    unitOfWork.Save();
                }
                return true;
            }
            catch{
                Console.WriteLine(doctor);
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                using(UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Doctor doctor = unitOfWork.DoctorRepository.GetByID(id);
                    unitOfWork.DoctorRepository.Delete(doctor);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
