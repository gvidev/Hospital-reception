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
    public class HospitalManagementService
    {

        public List<HospitalDTO> Get()
        {

            List<HospitalDTO> hospitalsDTO = new List<HospitalDTO>();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                foreach (var item in unitOfWork.HospitalRepository.Get())
                {
                    hospitalsDTO.Add(new HospitalDTO
                    {
                        Id = item.Id,
                        HospitalName = item.HospitalName,
                        Address = item.Address,
                        AddressNumber = item.AddressNumber,
                        City = item.City,
                        ContactNumber = item.ContactNumber,
                        Email = item.Email,
                    });
                }
            }
            return hospitalsDTO;

        }

        public HospitalDTO GetById(int id)
        {

            HospitalDTO hospitalDTO = new HospitalDTO();

            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                Hospital hospital = unitOfWork.HospitalRepository.GetByID(id);
                if (hospital != null)
                {
                    hospitalDTO = new HospitalDTO
                    {
                        Id = hospital.Id,
                        HospitalName = hospital.HospitalName,
                        Address = hospital.Address,
                        AddressNumber = hospital.AddressNumber,
                        City = hospital.City,
                        ContactNumber = hospital.ContactNumber,
                        Email = hospital.Email
                    };
                }

            }
            return hospitalDTO;

        }

        public bool Update(HospitalDTO hospitalDTO)
        {
            try
            {

                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Hospital hospital = unitOfWork.HospitalRepository.GetByID(hospitalDTO.Id);

                    if(hospital == null)
                    {
                        return false;
                    }

                    // Update the hospital entity with the new values
                    hospital.HospitalName = hospitalDTO.HospitalName;
                    hospital.Address = hospitalDTO.Address;
                    hospital.AddressNumber = hospitalDTO.AddressNumber;
                    hospital.City = hospitalDTO.City;
                    hospital.ContactNumber = hospitalDTO.ContactNumber;
                    hospital.Email = hospitalDTO.Email;

                    unitOfWork.HospitalRepository.Update(hospital);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Save(HospitalDTO hospitalDTO)
        {

            Hospital hospital = new Hospital
            {
                HospitalName = hospitalDTO.HospitalName,
                Address = hospitalDTO.Address,
                AddressNumber = hospitalDTO.AddressNumber,
                City = hospitalDTO.City,
                ContactNumber = hospitalDTO.ContactNumber,
                Email = hospitalDTO.Email
            };

            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    unitOfWork.HospitalRepository.Insert(hospital);
                    unitOfWork.Save();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (UnitOfWork unitOfWork = new UnitOfWork())
                {
                    Hospital hospital = unitOfWork.HospitalRepository.GetByID(id);
                    unitOfWork.HospitalRepository.Delete(hospital);
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
