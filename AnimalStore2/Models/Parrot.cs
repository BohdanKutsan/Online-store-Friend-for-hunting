using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnimalStore2.Models
{
    public class Dog : Animal
    {
        [Display(Name = "Призначення")]
        [Required(ErrorMessage = "Будь-ласка, введіть призначення собаки")]
        public string AppointmentOfDog { get; set; } //призначення
        [Display(Name = " Вид діяльності")]
        [Required(ErrorMessage = "Будь-ласка, введіть тип собаки")]
        public string TypeOfActivity { get; set; } // Вид діяльності
    }

}