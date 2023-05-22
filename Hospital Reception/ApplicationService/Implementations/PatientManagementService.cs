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
    public class PatientManagementService
    {

        public List<PatientDTO> Get()
        {
            List<PatientDTO> patientsDTO = new List<PatientDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.PatientRepository.Get())
                {

                    patientsDTO.Add(new PatientDTO
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Age = item.Age,
                        PhoneNumber = item.PhoneNumber,
                        Doctor_Id = item.Doctor_Id,
                        //Doctor = new DoctorDTO
                        //{
                        //    Id = item.Doctor.Id,
                        //    FirstName = item.Doctor.FirstName,
                        //    LastName = item.Doctor.LastName

                        //}
                    });
                }
            }
            return patientsDTO;
        }

        public PatientDTO GetById(int id)
        {
            PatientDTO patientDTO = new PatientDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Patient patient = unitOfWork.PatientRepository.GetByID(id);
                if (patient != null)
                {
                    patientDTO = new PatientDTO
                    {
                        Id = patient.Id,
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        Age = patient.Age,
                        PhoneNumber = patient.PhoneNumber,
                        Doctor_Id = patient.Doctor_Id,
                        //Doctor = new DoctorDTO
                        //{ 
                        //    Id = patient.Doctor.Id,
                        //    FirstName = patient.Doctor.FirstName,
                        //    LastName = patient.Doctor.LastName

                        //}


                    };

                }
            }
            return patientDTO;
        }

        public bool Update(PatientDTO patientDTO)
        {

            if (!DoctorCheck(patientDTO.Doctor_Id))
            {
                return false;
            }

            try
            {

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Patient patient = unitOfWork.PatientRepository.GetByID(patientDTO.Id);

                    if (patient == null)
                    {
                        return false;
                    }

                    // Update the hospital entity with the new values
                    patient.FirstName = patientDTO.FirstName;
                    patient.LastName = patientDTO.LastName;
                    patient.Age = patientDTO.Age;
                    patient.PhoneNumber = patientDTO.PhoneNumber;
                    patient.Doctor_Id = patientDTO.Doctor_Id;
                    //patient.Doctor = DoctorInfo(patientDTO.Doctor_Id);

                    unitOfWork.PatientRepository.Update(patient);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(PatientDTO patientDTO)
        {
            if (!DoctorCheck(patientDTO.Doctor_Id))
            {
                return false;
            }

            Patient patient = new Patient
            {
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                Age = patientDTO.Age,
                PhoneNumber = patientDTO.PhoneNumber,
                Doctor_Id = patientDTO.Doctor_Id,
               // Doctor = DoctorInfo(patientDTO.Doctor_Id)
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.PatientRepository.Insert(patient);
                    unitOfWork.Save();
                }
                return true;
            }
            catch
            {
                Console.WriteLine(patient);
                return false;
            }

        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Patient patient = unitOfWork.PatientRepository.GetByID(id);
                    unitOfWork.PatientRepository.Delete(patient);
                    unitOfWork.Save();
                }
                return true;
            }
            catch { return false; }
        }

        private bool DoctorCheck(int id)
        {

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {

                    Doctor doctor = unitOfWork.DoctorRepository.GetByID(id);
                    if (doctor == null)
                    {
                        return false;
                    }
                }
                return true;

            }
            catch
            {
                return false;
            }


        }

        private Doctor DoctorInfo(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {

                    Doctor doctor = unitOfWork.DoctorRepository.GetByID(id);
                    if (doctor != null)
                    {
                        return doctor;
                    }
                    return null;

                }
            }
            catch
            {
                return null;
            }
        }

    }
}
