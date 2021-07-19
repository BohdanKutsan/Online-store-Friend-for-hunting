using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalStore2.Models
{
        public class Dog : Animal
        {
        [Display(Name = "Призначення")]
        [Required(ErrorMessage = "Будь-ласка, введіть призначення тварини")]
        public string AppointmentOfDog { get; set; } //призначення
        [Display(Name = " Вид діяльності")]
        [Required(ErrorMessage = "Будь-ласка, введіть тип тварини")]
        public string TypeOfActivity { get; set; } // Вид діяльності
        }
}