using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AnimalStore2.Models
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Вкажіть як вас звати")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Вкажіть адрес доставки")]
        public string Line1 { get; set; }
       

        [Required(ErrorMessage = "Вкажіть номер телефону")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Вкажіть Email")]
        public string Email { get; set; }

    }
}