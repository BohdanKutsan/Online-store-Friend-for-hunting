using AnimalStore2.Models;
using AnimalStore2.Repository;
using AnimalStore2.WebUI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalStore2.Controllers
{
    public class CartController : Controller
    {
        UnitOfWork unitOfWork;
        
        public CartController()
        {
          
             unitOfWork = new UnitOfWork();
        }
      
        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
        public ViewResult Checkout()
        {
            if (Request.IsAuthenticated)
            {
                //string userid=User.Identity.GetUserId();

            }
            return View(new Order());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, Order order)
        {
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                foreach(var item in cart.Lines)
                {
                int id = item.AnimalId;
                Dog dog = unitOfWork.Dogs.Get(id);
                dog.OrderId = order.OrderId;
                dog.Status = false;
                unitOfWork.Dogs.Update(dog);

                }
                
                order.Date = DateTime.Now;
                order.Status = false;
                
                unitOfWork.Orders.Create(order);
                unitOfWork.Save();
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }
        public RedirectToRouteResult AddToCart(Cart cart, int id, string returnUrl)
        {
            Dog dog = unitOfWork.Dogs.Get(id); 

            if (dog != null)
            {
                cart.AddItem(dog);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            Dog dog = unitOfWork.Dogs.Get(id);

            if (dog != null)
            {
                cart.RemoveLine(dog);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        
    }
}