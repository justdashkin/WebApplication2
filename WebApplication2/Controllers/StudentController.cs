using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models.Context;
using WebApplication2.Models.Entities;
using WebApplication2.Models.Repository;

namespace WebApplication2.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        Repository db = new Repository();
        public ActionResult Index()
        {
            return View(db.GetStudents);
        }
        public ActionResult Details(int id)
        {
            ViewBag.LstCours = db.GetCoursesToStudent(id);
            return View(db.GetStudent(id));
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                db.CreateStudent(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ViewBag.LstCourseStudent = db.GetCoursesToStudent(id).Select(x => x.Title).ToList();
            ViewBag.LstCourses = db.GetCourses;
            return View(db.GetStudent(id));
        }

        [HttpPost]
        public ActionResult Edit(Student student, String[] selectedCourse)
        {
            if (!ModelState.IsValid) {
                return View();
            }
            try {
                db.EditStudent(student, selectedCourse);
                TempData["EditStudent"] = "UpdaitedStudent " + student.FirstName;
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            return View(db.GetStudent(id));
        }
        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            try {
                db.DeleteStudent(id);
                return RedirectToAction("Index");
            }
            catch {
                return View();
            }
        }

    }
}