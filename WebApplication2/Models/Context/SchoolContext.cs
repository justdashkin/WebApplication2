using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication2.Models.Entities;

namespace WebApplication2.Models.Context
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(): base("SchoolContext"){ }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
    }
}