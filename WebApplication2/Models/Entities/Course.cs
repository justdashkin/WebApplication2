using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.Collections.Generic;

namespace WebApplication2.Models.Entities
{
    public class Course
    {
        public int CourseID{ get; set; }
        [DisplayName("Дисциплина")]
        public string Title { get; set; }

        [DisplayName("Количество баллов")]
        public int Credits{ get; set; }

        [DisplayName("Сдача сессии")]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}