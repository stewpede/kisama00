using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Areas.Security.Models;
using WebApplication1.Dal;

namespace WebApplication1.Areas.Security.Controllers
{
    public class UsersController : Controller
    {
        public UsersController()
        {
            var genders = new List<SelectListItem> {
                new SelectListItem
                {
                    Value = "Male",
                    Text = "Male"
                },
                new SelectListItem
                {
                    Value = "Female",
                    Text = "Female"
                }
            };
            ViewBag.Genders = genders;
        }

        // GET: Security/Users
        public ActionResult Index()
        {
            using (var db = new DatabaseContext())
            {
                var users = (from user in db.Users
                             select new UserViewModel
             {
                 Id = user.Id,
                 FirstName = user.FirstName,
                 MiddleName = user.MiddleName,
                 ContactNo = user.ContactNo,
                 LastName = user.LastName,
                 Age = user.Age,
                 Gender = user.Gender
             }).ToList();               
                return View(users);

            }
            
        }

        // GET: Security/Users/Details/5
        public ActionResult Details(int id)
        {
            return View(GetUser(id));
        }

        // GET: Security/Users/Create
        public ActionResult Create()
        {
            ViewBag.Genders = new List<SelectListItem>{
                new SelectListItem
                {
                    Value = "Male",
                    Text = "Male",
                },
                new SelectListItem
                {
                    Value = "Female",
                    Text = "Female"
                },
            };
            return View();
        }

        // POST: Security/Users/Create
        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid == false)
                    return View();


                using (var db = new DatabaseContext())
                {
                    db.Users.Add(new User
                    {
                       // Id = Guid.NewGuid(),
                        FirstName = viewModel.FirstName,
                        MiddleName = viewModel.MiddleName,
                        ContactNo = viewModel.ContactNo,
                        LastName = viewModel.LastName,
                        Age = viewModel.Age,
                        Gender = viewModel.Gender,
                    });
                    db.SaveChanges();
                }
                    
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetUser(id));
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserViewModel viewModel)
        {
            try
            {
              /*  var u = Users.FirstOrDefault(user => user.Id == id);
                u.FirstName = viewModel.FirstName;
                u.LastName = viewModel.LastName;
                u.Age = viewModel.Age;
                u.Gender = viewModel.Gender;*/

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetUser(id));
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                   using (var db = new DatabaseContext())
                   {
                var s = db.Users.FirstOrDefault(user => user.Id == id);
                db.Users.Remove(s);
                db.SaveChanges();
                   }
                return RedirectToAction("Index");

                   }
            catch
            {
                return View();
            }
        }


        private UserViewModel GetUser(int id)
        {
            using (var db = new DatabaseContext())
            {
                return (from user in db.Users
                        where user.Id == id
                        select new UserViewModel
                        {
                            FirstName = user.FirstName,
                            MiddleName = user.MiddleName,
                            ContactNo = user.ContactNo,
                            LastName = user.LastName,
                            Age = user.Age,
                            Gender = user.Gender
                        }).FirstOrDefault();
            }
        }
    }
}
