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
                        PhoneNumber = item.PhoneNumber,
                        Hospital_Id = item.Hospital_Id
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
                        Id = doctor.Id,
                        FirstName = doctor.FirstName,
                        LastName = doctor.LastName,
                        Age = doctor.Age,
                        PhoneNumber = doctor.PhoneNumber,
                        Hospital_Id = doctor.Hospital_Id

                    };

                }
            }
            return doctorDTO;
        }


        public bool Update(DoctorDTO doctorDTO)
        {
            if (!HospitalCheck(doctorDTO.Hospital_Id))
            {
                return false;
            }

            try
            {

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Doctor doctor = unitOfWork.DoctorRepository.GetByID(doctorDTO.Id);

                    if (doctor == null)
                    {
                        return false;
                    }
                        // Update the hospital entity with the new values
                        doctor.FirstName = doctorDTO.FirstName;
                    doctor.LastName = doctorDTO.LastName;
                    doctor.Age = doctorDTO.Age;
                    doctor.PhoneNumber = doctorDTO.PhoneNumber;
                    doctor.Hospital_Id = doctorDTO.Hospital_Id;


                    unitOfWork.DoctorRepository.Update(doctor);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(DoctorDTO doctorDTO)
        {
            if (!HospitalCheck(doctorDTO.Hospital_Id))
            {
                return false;
            }

            Doctor doctor = new Doctor
            {
                FirstName = doctorDTO.FirstName,
                LastName = doctorDTO.LastName,
                Age = doctorDTO.Age,
                PhoneNumber = doctorDTO.PhoneNumber,
                Hospital_Id = doctorDTO.Hospital_Id
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.DoctorRepository.Insert(doctor);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                Console.WriteLine(doctor);
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
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

        private bool HospitalCheck(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Hospital hospital = unitOfWork.HospitalRepository.GetByID(id);
                    if (hospital == null)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch
            { return false; }
        }

    }
}
