using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;

namespace WebApplication2.Models.Entities
{
    public class Enrollment
    {
        public int EnrollmentID{ get; set; }

        [DisplayName("Дисциплина")]
        public int CourseID { get; set; }

        [DisplayName("Студент")]
        public int StudentID { get; set; }

        [DisplayName("Оценка")]
        public int? Grade { get; set; }
        public virtual Course Course{ get; set; }
        public virtual Student Student{ get; set; }
    }
}