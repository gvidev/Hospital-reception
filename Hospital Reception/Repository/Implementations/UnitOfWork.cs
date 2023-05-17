using Data.Context;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Implementations
{
    public class UnitOfWork : IDisposable
    {
        private HospitalReceptionDbContext context = new HospitalReceptionDbContext();
        private GenericRepository<Doctor> doctorRepository;
        private GenericRepository<Patient> patientRepository;
        private GenericRepository<Hospital> hospitalRepository;

        public GenericRepository<Doctor> DoctorRepository
        {
            get
            {

                if (this.doctorRepository == null)
                {
                    this.doctorRepository = new GenericRepository<Doctor>(context);
                }
                return doctorRepository;
            }
        }

        public GenericRepository<Patient> PatientRepository
        {
            get
            {
                if (this.patientRepository == null)
                {
                    this.patientRepository = new GenericRepository<Patient>(context);
                }
                return patientRepository;
            }
        }
        
        public GenericRepository<Hospital> HospitalRepository
        {
            get
            {
                if(this.hospitalRepository == null)
                {
                    this.hospitalRepository = new GenericRepository<Hospital>(context);
                }
                return hospitalRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
