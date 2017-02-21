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
        private IList<UserViewModel> Users
        {
            get
            {
                if (Session["data"] == null)
                {
                    Session["data"] = new List<UserViewModel>(){
                        new UserViewModel {

                            Id = Guid.NewGuid(),
                            FirstName = "Lem",
                            LastName = "Muel",
                            Age = 15,
                            Gender = "Female"
                        },
                        new UserViewModel {

                            Id = Guid.NewGuid(),
                            FirstName = "Lem",
                            LastName = "My",
                            Age = 15,
                            Gender = "Male"
                        }
                    };
                } 
                return Session["data"] as List<UserViewModel>; 
            }
            

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
                 LastName = user.LastName,
                 Age = user.Age,
                 Gender = user.Gender
             }).ToList();               
                return View(users);

            }
            
        }

        // GET: Security/Users/Details/5
        public ActionResult Details(Guid id)
        {
            var u = Users.FirstOrDefault(user => user.Id == id);
            return View(u);
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
                        Id = Guid.NewGuid(),
                        FirstName = viewModel.FirstName,
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
        public ActionResult Edit(Guid id)
        {
            var u = Users.FirstOrDefault(user => user.Id == id);
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
                }
            };
            return View(u);
        }

        // POST: Security/Users/Edit/5
        [HttpPost]
        public ActionResult Edit(Guid id, UserViewModel viewModel)
        {
            try
            {
                var u = Users.FirstOrDefault(user => user.Id == id);
                u.FirstName = viewModel.FirstName;
                u.LastName = viewModel.LastName;
                u.Age = viewModel.Age;
                u.Gender = viewModel.Gender;

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Security/Users/Delete/5
        public ActionResult Delete(Guid id)
        {
            var u = Users.FirstOrDefault(user => user.Id == id);
            return View(u);
        }

        // POST: Security/Users/Delete/5
        [HttpPost]
        public ActionResult Delete(Guid id, FormCollection collection)
        {
            try
            {
                var u = Users.FirstOrDefault(user => user.Id == id);
                Users.Remove(u);
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
