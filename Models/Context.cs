using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELab_NetCore_API.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<TestType> TestTypes { get; set; }
        public DbSet<TestParam> TestParams { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
