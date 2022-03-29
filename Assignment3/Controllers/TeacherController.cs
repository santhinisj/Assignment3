using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3.Models;

namespace Assignment3.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }
        //GET : Teacher/List
        //list all teachers
        public ActionResult List()
        {
            //connect to data access layer
            //pass teachers to the view List.cshtml
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }
        //GET : Teacher/Show/9
        [Route("/Teacher/show/{id}")]
        public ActionResult Show(int id)
        {
            //display a teacher from the database
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);
            return View(SelectedTeacher);
        }
    }

}