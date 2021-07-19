using AnimalStore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalStore2.WebUI
{
    public class DogsListViewModel
    {
        public IEnumerable<Dog> Dogs { get; set; }
        public SelectList TypeOfActivity { get; set; }
        public SelectList Breed { get; set; }
    }
}