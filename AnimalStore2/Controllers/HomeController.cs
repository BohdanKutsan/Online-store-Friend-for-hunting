using AnimalStore2.Models;
using AnimalStore2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalStore2.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork;
        public HomeController()
        {
            unitOfWork = new UnitOfWork();
        }
        public ActionResult EditOrder(int id)
        {
            Order order = unitOfWork.Orders.Get(id);
            if (order == null)
                return HttpNotFound();
            return View(order);
        }

        [HttpPost]
        public ActionResult EditOrder(Order order)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.Orders.Update(order);
                unitOfWork.Save();
                TempData["message"] = string.Format("Зміни в записі про тварину \"{0}\" були збережені", order.Name);
                return RedirectToAction("GetAllOrder");

            }
            else
            {
                // Что-то не так со значениями данных
                return View(order);
            }
        }

        public ActionResult GetAllOrder()
        {
            var orders = unitOfWork.Orders.GetAll().Where(p => p.Status == false);
            
            return View(orders);
        }
       
        public ActionResult DetailsOrder(int id)
        {

           
            var dogs = unitOfWork.Dogs.GetAll().Where(p => p.OrderId == id);
            ViewBag.order = unitOfWork.Orders.Get(id);
            return View(dogs);
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
        
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}