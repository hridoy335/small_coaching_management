using small_coaching_management.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace small_coaching_management.Controllers
{
    public class HomeController : Controller
    {
        Models.small_coaching_managementEntities1 db = new Models.small_coaching_managementEntities1(); 
        public ActionResult Index()
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
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
        public ActionResult Teacher_registration()
        {
            return View();
        }

        [HttpPost]
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
       
        public ActionResult Schedule(int id=0)
        {
            ViewBag.Message = "Your Schedule page.";

            Schedule schedule = new Schedule();
            schedule.TeacherCollection = db.Teachers.ToList<Teacher>();
            schedule.ClassCollection = db.Classes.ToList<Class>();

            ViewBag.Courses = new SelectList(db.Courses, "CourseId", "CourseName");

            return View(schedule);
        }

        //Schedule 
        [HttpPost]
        public ActionResult Schedule(Models.Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Schedules.Add(schedule);
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Schedule");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                }
            }
            return View();
        }

        public ActionResult Student_Bill(Models.StudentBill studentBill)
        {
            ViewBag.Message = "Your application description page.";
            return View(db.StudentBills.ToList());
        }
      
        [HttpGet]
        public ActionResult Student_Edit(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Student_Edit = db.Students.Find(id);
            if (Student_Edit == null)
            {
                return HttpNotFound();
            }
            return View(Student_Edit);  
        }


        [HttpPost]
        public ActionResult Student_Edit([Bind(Include =
        "StudentId, StudentName,StudentContact,StudentAddress,studentClass,UserName,UserPassword,PamentAmount")] Student Student_Edit) 
        {
            if (ModelState.IsValid)
            {
                db.Entry(Student_Edit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Student_information");
            }
            return View(Student_Edit);
        }

        [HttpGet]
        public ActionResult Teacher_Edit(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Teacher_Edit = db.Teachers.Find(id);
            if(Teacher_Edit==null)
            {
                return HttpNotFound();
            } 

            return View(Teacher_Edit);
        }

        [HttpPost]
        public ActionResult Teacher_Edit([Bind(Include =
        "TeacherId, TeacherName,Contact,Address,UserName,UserPassword")] Teacher Teacher_Edit)
        {
            if(ModelState.IsValid)
            {
                db.Entry(Teacher_Edit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Teacher_information");
            }
            return View(Teacher_Edit);
        }

        public ActionResult Schedule_Information()
        {
            return View(db.Schedules.ToList());
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)  
        {
            var Login = db.Students.Where(x => x.UserName == username && x.UserPassword == password).FirstOrDefault(); 
           
            if(Login==null)
            {
                
               
                var tea = db.Teachers.Where(x => x.UserName == username && x.UserPassword == password).FirstOrDefault();
                if(tea==null)
                {
                    ViewBag.message = "Login fail";
                    return View("Login");
                }
               else
                {
                    Session["username"] = tea.UserName.ToString();
                    return RedirectToAction("Index", "Home");
                }

        

            }
            else
            {
           

                Session["username"] = Login.StudentId.ToString(); 
              
                return RedirectToAction("Student", "Home");
            }  
            
       
        }

        public ActionResult Trangection(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var StudentBilId = db.StudentBills.Find(id);
            if (StudentBilId == null)
            {
                return HttpNotFound();
            }

            return View(StudentBilId);
        }

        [HttpPost]
        public ActionResult Trangection(StudentBill stbill)
        {
            Transcetion trns = new Transcetion();
            trns.TransectionnDate = DateTime.Now;
            trns.StudentBillId = stbill.StudentBilId;

                db.Transcetions.Add(trns);
                db.SaveChanges();
                return RedirectToAction("Student_Bill");
            
            
        }

        public ActionResult Tranjection_Info()
        {
            return View(db.Transcetions.ToList());
        }

        public ActionResult Student()  
        {
            if (Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            };
        }

        public ActionResult Student_Info()
        {
            int sess = Convert.ToInt32(Session["username"]);
            return View(db.Students.Where(x => x.StudentId == sess).ToList());
        }

        public ActionResult TeacherLogOut()  
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }

        public ActionResult Student_Schedule()
        {
            int sess = Convert.ToInt32(Session["username"]);
            int classId = db.StudentClasses.FirstOrDefault(x => x.StudentId == sess).ClassId;
            int schedule = db.Schedules.FirstOrDefault(x => x.ClassId == classId).ScheduleId;



            return View(db.Schedules.Where(x => x.ScheduleId == schedule).ToList());
        }
    }
}