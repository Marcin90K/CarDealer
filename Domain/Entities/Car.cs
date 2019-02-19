using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Domain.Entities
{
    public class Car
    {
        [HiddenInput(DisplayValue=false)]
        public int Id { get; set; }

        // [Required(ErrorMessage = "Podaj markę pojazdu")]
        [Display(Name="Marka")]
        public string Brand { get; set; }

        //[Required(ErrorMessage = "Podaj model pojazdu")]
        [Display(Name="Model")]
        public string Model { get; set; }

        //[Required(ErrorMessage = "Podaj datę produkcji")]
        [Display(Name = "Data produkcji")]
        public DateTime ManufactDate { get; set; }

        //[Required(ErrorMessage = "Podaj rodzaj pojazdu")]
        [Display(Name = "Typ")]
        public string Type { get; set; }

        //[Required(ErrorMessage = "Podaj typ silnika")]
        [Display(Name = "Rodzaj paliwa")]
        public string EngineType { get; set; }

        //[Required(ErrorMessage = "Podaj pojemność silnika")]
        [Display(Name = "Pojemność silnika")]
        public int EngineCapacity { get; set; }

        //[Range(0, 1000000)]
        //[Required(ErrorMessage = "Podaj cenę pojazdu")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }

        //[DataType(DataType.MultilineText), Display(Name="Opis")]
        [Display(Name = "Opis")]
        public string Description { get; set; }

        [HiddenInput(DisplayValue=false)]
        public byte[] ImageData { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ImageMimeType { get; set; }
    }
}
