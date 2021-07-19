using AnimalStore2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalStore2.Controllers
{
    public class NavController : Controller
    {
        UnitOfWork unitOfWork;
        public NavController()
        {
            unitOfWork = new UnitOfWork();
        }
        public PartialViewResult Menu(string type = null)
        {
            ViewBag.SelectedType = type;
            IEnumerable<string> types = unitOfWork.Dogs.GetAll()
                .Select(item => item.TypeOfActivity)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(types);
        }
    }
}

