using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Models.Entities;
using WebApplication2.Models.Context;
using System.Data;
using System.Data.Entity;


namespace WebApplication2.Models.Repository
{
    public class Repository
    {
        SchoolContext db;
        public Repository() {
            db = new SchoolContext();
        }
        public List<Student> GetStudents
        {
            get { return db.Students.ToList<Student>(); }
        }
        public Student GetStudent(Int32 StudentId) {
            return db.Students.Find(StudentId);
        }
        public void EditStudent(Student student) {
            db.Entry(student).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void CreateStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public void DeleteStudent(int id) {
            db.Students.Remove(db.Students.Find(id));
            db.SaveChanges();
        }

        public void EditStudent(Student student, String[] selectedCourses)
        {//edit chosen courses
            db.Entry(student).State = EntityState.Modified;
            if (selectedCourses != null)
            {
                List<Enrollment> ListCoursToStudent = db.Enrollments.Where(x => x.StudentID == student.StudentID).ToList();
                foreach (Enrollment item in ListCoursToStudent)
                {
                    if (!selectedCourses.Contains(item.CourseID.ToString()))
                    {
                        db.Enrollments.Remove(item);
                    }
                }
                foreach (String itemCourse in selectedCourses)
                {

                    if (ListCoursToStudent.Find(x => x.CourseID == Convert.ToInt32(itemCourse)) == null)
                    {
                        db.Enrollments.Add(new Enrollment
                        {
                            StudentID = student.StudentID,
                            CourseID = Convert.ToInt32(itemCourse)
                        });
                    }
                }
            }
                db.SaveChanges();
            }
        public List<Course> GetCoursesToStudent(Int32 StudentId)
        {
            List<Int32> LstCoursId = db.Enrollments.Where(x => x.StudentID == StudentId).Select(x => x.CourseID).ToList<Int32>();
            List<Course> LstCourses = new List<Course>(); foreach (Int32 id in LstCoursId) { LstCourses.Add(db.Courses.Find(id)); }
            return LstCourses;
        }
        public List<Course> GetCourses {
            get { return db.Courses.ToList<Course>(); }
        }
        public List<String> GetCoursesTitle {
            get {return db.Courses.Select(x => x.Title).ToList<String>();}
        }
    }
} 