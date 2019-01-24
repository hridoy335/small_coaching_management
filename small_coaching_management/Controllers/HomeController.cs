using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace small_coaching_management.Controllers
{
    public class HomeController : Controller
    {
        Models.small_coaching_managementEntities1 db = new Models.small_coaching_managementEntities1(); 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Student_Registration()  
        {
            ViewBag.Message = "Your application description page.";
          

            return View();
        }

        [HttpPost]
        public ActionResult Student_Registration(Models.Student student)
        {
            ViewBag.Message = "Your application description page.";
            if(ModelState.IsValid)
            {
                db.Students.Add(student);
                    try
                {
                    db.SaveChanges();
                    return RedirectToAction("Student_Registration");
                }
                catch(Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }

            return View();
        }
        public ActionResult Student_Information() 
        {
            ViewBag.Message = "Student Registration Page ";
           

            return View(db.Students.ToList());
        }

        public ActionResult Teacher_registration(Models.Teacher teacher) 
        {
            ViewBag.Message = "Your Course page.";
            if(ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Teacher_registration");
                }
                catch(Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }
            return View();
        }

        public ActionResult Teacher_information() 
        {
            ViewBag.Message = "Your Course page.";

            return View(db.Teachers.ToList());
        }

        public ActionResult Schedule()
        {
            ViewBag.Message = "Your Schedule page.";
           
            
            return View();
        }

        public ActionResult Student_Bill(Models.StudentBill studentBill)
        {
            ViewBag.Message = "Your application description page.";
            return View(db.StudentBills.ToList());
        }
        

    }
}