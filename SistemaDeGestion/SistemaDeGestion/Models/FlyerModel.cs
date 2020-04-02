using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SistemaDeGestion.Models
{
    public class FlyerModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "La {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(150,ErrorMessage = "La {0} debe tener al menos {1} caracteres", MinimumLength = 1)]
        public string Description { get; set; }
        [Required]
        public string Imagen { get; set; }

    }

    public class DeleteFlyerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Imagen { get; set; }

    }
}