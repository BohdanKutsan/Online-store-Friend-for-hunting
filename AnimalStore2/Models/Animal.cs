using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnimalStore2.Models
{
    public class Animal
    {
        public Animal()
        {

        }
        [HiddenInput(DisplayValue = false)]
        public int AnimalId { get; set; }


        [Display(Name = "Ім'я")]
        [Required(ErrorMessage = "Будь-ласка, введіть ім'я тварини")]
        public string Name { get; set; }      //назва
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Будь-ласка, введіть опис тварини")]
        [Display(Name = "Опис")]
        public string Description { get; set; } //опис
        [Display(Name = "Порода")]
        [Required(ErrorMessage = "Будь-ласка, введіть породу тварини")]
        public string Breed { get; set; }     //порода
        [Display(Name = "Вік")]
        [Required(ErrorMessage = "Будь-ласка, введіть вік тварини")]
        public int Age { get; set; }         //вік
        [Required(ErrorMessage = "Будь-ласка, введіть окрас тварини")]
        [Display(Name = "Окрас")]
        public string ColorOfAnimal { get; set; }


        [Display(Name = "Ціна")]
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Будь-ласка, введіть позитивне число для ціни")]
        [Column(TypeName = "money")]
        public decimal Price { get; set; } //Ціна
        [Display(Name = "Доступність для замовлення")]
        public bool Status { get; set; } //доступність для покупки
        [Display(Name = "Шлях до зображення")]
        public string PathImage { get; set; } // шлях до зображення
        [Display(Name = "Номер замовлення")]
        public int? OrderId { get; set; }
        public  Order order { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }
    }
}