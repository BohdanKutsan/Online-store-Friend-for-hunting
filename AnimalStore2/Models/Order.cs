using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AnimalStore2.Models
{
    [Table("Orders")]
    public class Order
    {
        public int OrderId { get; set; }
        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Вкажіть як вас звати")]
        public string Name { get; set; }
        [Display(Name = "Адреса")]
        [Required(ErrorMessage = "Вкажіть адрес доставки")]
        public string Line1 { get; set; }

        [Display(Name = "Номер телефону")]
        [Required(ErrorMessage = "Вкажіть номер телефону")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Вкажіть Email")]
        public string Email { get; set; }



        public DateTime Date { get; set; }
        public bool Status { get; set; } // оброблений не оброблений

       
       

        //public  ICollection<int> _AnimalsId { get; set; }
        //public Order()
        //{
        //    _AnimalsId = new List<int>();
        //}

    }
}