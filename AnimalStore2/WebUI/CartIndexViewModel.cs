using AnimalStore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalStore2.WebUI
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}