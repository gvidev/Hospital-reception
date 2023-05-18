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
                        Doctor = new DoctorDTO
                        {
                            Id = item.Doctor.Id,
                            FirstName = item.Doctor.FirstName,
                            LastName = item.Doctor.LastName
                        }
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
                        FirstName = patient.FirstName,
                        LastName = patient.LastName,
                        Age = patient.Age,
                        PhoneNumber = patient.PhoneNumber,
                        // you can create a search for this object based on NationalityId and load it here
                        Doctor = new DoctorDTO
                        {
                            Id = patient.Doctor.Id,
                            FirstName = patient.Doctor.FirstName,
                            LastName = patient.Doctor.LastName,
                        }
                    };

                }
            }
            return patientDTO;
        }

        public bool Save(PatientDTO patientDTO)
        {
            if (patientDTO.Doctor_Id == 0)
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
                using(UnitOfWork unitOfWork =new UnitOfWork())
                {
                    Patient patient = unitOfWork.PatientRepository.GetByID(id);
                    unitOfWork.PatientRepository.Delete(patient);
                    unitOfWork.Save();
                }
                return true;
            }
            catch { return false; }
        }

    }
}
