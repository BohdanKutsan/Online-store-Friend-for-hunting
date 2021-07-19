using AnimalStore2.Models;
using AnimalStore2.Repository;
using AnimalStore2.WebUI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalStore2.Controllers
{
    public class DogsController : Controller
    {
        UnitOfWork unitOfWork;
        public DogsController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult List(string type, int page = 1)
        {
           


            var dogs = unitOfWork.Dogs.GetAll().Where(p => (type == null & p.Status == true) || (p.TypeOfActivity == type & p.Status==true));


            int pageSize = 3; // количество объектов на страницу
            IEnumerable<Dog> dogsPerPages = dogs.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems =type==null? dogs.Count(): dogs.Where(item=>item.TypeOfActivity == type).Count() };
            IndexViewModelDogs dog = new IndexViewModelDogs { PageInfo = pageInfo, Dogs = dogsPerPages };
            dog.CurrentTypeOfActivity = type;
            return View(dog);

           
        }

        public ActionResult Details(int id)
        {

            var dog = unitOfWork.Dogs.Get(id);


            return View(dog);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
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
                return RedirectToAction("List");
            }
            return View(dog);
        }

        public ActionResult Edit(int id)
        {
            Dog dog = unitOfWork.Dogs.Get(id);
            if (dog == null)
                return HttpNotFound();
            return View(dog);
        }

        [HttpPost]
        public ActionResult Edit(Dog dog)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Dogs.Update(dog);
                unitOfWork.Save();
                return RedirectToAction("Index");
            }
            return View(dog);
        }

        public ActionResult Delete(int id)
        {
            unitOfWork.Dogs.Delete(id);
            unitOfWork.Save();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}