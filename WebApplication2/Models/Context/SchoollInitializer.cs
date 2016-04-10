using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.Entities;
using System.Data.Entity;

namespace WebApplication2.Models.Context
{
    public class SchoollInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            List<Student> students = new List<Student> {
                new Student{ FirstName= "Иван", LastName= "Иванов", EnrollmentDate= DateTime.Parse("2011-07-01") },
                new Student{ FirstName= "Петр", LastName= "Петров", EnrollmentDate= DateTime.Parse("2012-08-02") },
                new Student{ FirstName= "Сидор", LastName= "Сидоров",EnrollmentDate= DateTime.Parse("2013-09-03") }
            };
             students.ForEach(s => context.Students.Add(s));
             context.SaveChanges();

           List<Course> courses = new List<Course> {
               new Course{ Title = "Веб-технологии", Credits = 3, },
               new Course{ Title = "Програмирование", Credits = 4, },
               new Course{ Title = "История", Credits = 2, }
           };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();

            context.Enrollments.Add(new Enrollment{ StudentID = 1, CourseID = 1, Grade = 5 });
            context.Enrollments.Add(new Enrollment { StudentID = 1, CourseID = 2, Grade = 3 });
            context.Enrollments.Add(new Enrollment { StudentID = 1, CourseID = 3, Grade = 4 });
            context.Enrollments.Add(new Enrollment { StudentID = 2, CourseID = 1, Grade = 5 });
            context.Enrollments.Add(new Enrollment { StudentID = 2, CourseID = 2, Grade = 4 });
            context.Enrollments.Add(new Enrollment { StudentID = 2, CourseID = 3, Grade = 4 });
            context.Enrollments.Add(new Enrollment { StudentID = 3, CourseID = 1, Grade = 3 });
            context.Enrollments.Add(new Enrollment { StudentID = 3, CourseID = 2, Grade = 2 });
            context.Enrollments.Add(new Enrollment { StudentID = 3, CourseID = 3 });

            context.SaveChanges();

        }
     }
}