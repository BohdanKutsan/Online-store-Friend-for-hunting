using AnimalStore2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalStore2.WebUI
{
    public class IndexViewModelDogs
    {

        public IEnumerable<Dog> Dogs { get; set; }
        public PageInfo PageInfo { get; set; }
        public string CurrentTypeOfActivity { get; set; }

    }
}