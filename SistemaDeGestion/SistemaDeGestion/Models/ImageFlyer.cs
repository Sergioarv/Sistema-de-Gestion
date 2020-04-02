using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestion.Models
{
    public class ImageFlyer
    {
        [Display(Name = "Imagen")]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "La {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "La {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Description { get; set; }
        public string Imagen { get; set; }
    }

    public class EditImageFlyer
    {
        public int Id { get; set; }
        [Display(Name = "Imagen")]
        public HttpPostedFileBase ImageFile { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "La {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Description { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "La {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Name { get; set; }
        public string Imagen { get; set; }
    }
}