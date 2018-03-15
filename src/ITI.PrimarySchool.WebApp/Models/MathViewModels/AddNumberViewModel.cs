using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITI.PrimarySchool.WebApp.Models.MathViewModels
{
    public class AddNumberViewModel
    {
        [Required]
        [Range(0, 100)]
        [Display(Name = "Nombre 1")]
        public int Number1 { get; set; }

        [Required]
        [Range(0, 100)]
        [Display(Name = "Nombre 2")]
        public int Number2 { get; set; }

        public int Total { get; set; }
    }
}
