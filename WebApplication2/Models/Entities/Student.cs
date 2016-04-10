using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;

namespace WebApplication2.Models.Entities
{
    public class Student
    {
        public int StudentID{ get; set; }

        [DisplayName("Фамилия")]
        public string LastName{ get; set; }

        [DisplayName("Имя")]
        public string FirstName{ get; set; }

        [DisplayName("Дата")]
        public DateTime EnrollmentDate{ get; set; }

        [DisplayName("Сдача сессии")]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}