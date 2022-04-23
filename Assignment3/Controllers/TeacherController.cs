using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        //GET : /Author/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }


        //POST : /Teacher/Delete/{id}
        [HttpPost]
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET : /Teacher/New
        public ActionResult New()
        {
            return View();
        }

        //POST : /Teacher/Create
        [HttpPost]
        public ActionResult Create(string TeacherFname, string TeacherLname,string EmployeeNumber, decimal Salary)
        {
            //Identify that this method is running
            //Identify the inputs provided from the form

            Debug.WriteLine("I have accessed the Create Method!");
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.EmployeeNumber = EmployeeNumber;


            NewTeacher.Salary = Salary;

            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }

        /// <summary>
        /// This method retrieves the data and show the details of selected author in the webpage
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //GET : /Teacher/Update/{id}
        public ActionResult Update(int id)
        {

            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);
            return View(SelectedTeacher);
        }

        /// <summary>
        /// This method updates the data in the web to the database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //POST: /Teacher/Update/{id}
        [HttpPost] 

        public ActionResult Update(int id, string teacherfname, string teacherlname, decimal salary)
        {

            Teacher Teacher = new Teacher();
            Teacher.TeacherFname = teacherfname;
            Teacher.TeacherLname = teacherlname;
            Teacher.Salary = salary;
            Teacher.TeacherId = id;

            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(Teacher);
            //return to the updated teacher page
            return RedirectToAction("Show/" + id);
        }


    }

}