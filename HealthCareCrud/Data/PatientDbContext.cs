using HealthCareCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace HealthCareCrud.Data
{
    public class PatientDbContext:DbContext
    {
        public PatientDbContext() : base()
        { }

    public  DbSet<Patient> Patients { get; set; }
    public DbSet<PatientHistory> PatientHistory { get; set; }   
          
    }
    
}