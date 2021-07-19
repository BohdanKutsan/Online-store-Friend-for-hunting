using AnimalStore2.Models;
using AnimalStore2.Repository;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalStore2.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        ApplicationDbContext context;
        UnitOfWork unitOfWork;
        public AdminController()
        {
            context = new ApplicationDbContext();
            unitOfWork = new UnitOfWork();
        }



        public ActionResult Index()
        {
            var animals = unitOfWork.Animals.GetAll();
            return View(animals);
        }

        public ActionResult ListUsers()
        {
            
            var users = context.Users;
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
         

            return View(users);
        }
        public ActionResult CreateUser()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Dog dog)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Dogs.Create(dog);
                unitOfWork.Save();
                TempData["message"] = string.Format("Тварину \"{0}\" створено", dog.Name);
                return RedirectToAction("Index");
            }
            return View(dog);
        }
        public ActionResult Delete(int id)
        {
            unitOfWork.Animals.Delete(id);
            unitOfWork.Save();
            TempData["message"] = string.Format("Тварину було видалено");
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            Dog dog = unitOfWork.Dogs.Get(id);
            if (dog == null)
                return HttpNotFound();
            return View(dog);
        }

        [HttpPost]
        public ActionResult Edit(Dog dog, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
            //    dog.ImageMimeType = image.ContentType;
            //    dog.ImageData = new byte[image.ContentLength];
            //    image.InputStream.Read(dog.ImageData, 0, image.ContentLength);
                unitOfWork.Dogs.Update(dog);
                unitOfWork.Save();
                TempData["message"] = string.Format("Зміни в записі про тварину \"{0}\" були збережені", dog.Name);
                return RedirectToAction("Index");
                
            }
            else
            {
                // Что-то не так со значениями данных
                return View(dog);
            }
        }
        public RedirectToRouteResult DeleteUser(string _email )
        {
            return RedirectToAction("DeleteConfirmed", "Account", new {email=_email });
        }

        public RedirectToRouteResult DetailsUser(string _Id)
        {
            return RedirectToAction("DetailsUser", "Account", new { Id=_Id });
        }
        public RedirectResult RegisterUser()
        {
            return RedirectPermanent("/Account/Register");
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }
}