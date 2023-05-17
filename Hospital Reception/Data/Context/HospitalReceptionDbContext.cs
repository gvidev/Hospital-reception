using Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class HospitalReceptionDbContext : DbContext
    {

        DbSet<Doctor> Doctors { get; set; }
        DbSet<Hospital> Hospitals { get; set; }
        DbSet<Patient> Patients { get; set; }

    }
}
