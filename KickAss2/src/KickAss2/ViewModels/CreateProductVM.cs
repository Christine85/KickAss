using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KickAss2.ViewModels
{
    public class CreateProductVM
    {
        [Display(Name = "Produktnamn")]
        [Required(ErrorMessage = "Du måste ange namn för produkten.")]
        public string Name { get; set; }

        [Display(Name = "Antal")]
        [Required(ErrorMessage = "Du måste ange antal för att lägga till.")]
        public int Stock { get; set; }

        [Display(Name = "Beskrivning")]
        [Required(ErrorMessage = "Fyll i en beskrivning av produkten.")]
        public string Description { get; set; }

        [Display(Name = "Pris (SEK)")]
        [Required(ErrorMessage = "Du måste ange ett pris.")]
        public float Price { get; set; }

        public SelectListItem[] CategoryIdList { get; set; }
        [Display(Name = "Kategori ID")]
        [Required(ErrorMessage = "Du måste ange vilken kategori produkten tillhör.")]
        public int SelectedCategoryId { get; set; }
    }
}
