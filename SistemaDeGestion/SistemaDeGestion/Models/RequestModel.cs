using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaDeGestion.Models
{
    public class RequestModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        [EmailAddress]
        public string Correo { get; set; }
        [Required]
        public string Telefono { get; set; }
        public int? Estado { get; set; }
        [Required]
        public string Descripcion { get; set; }
        [Required]
        public string Destino { get; set; }
        [Required]
        public string Origen { get; set; }
        public string RutaFile { get; set; }
        public DateTime? fechaSolicitud { get; set; }
        public DateTime? fechaEntrega { get; set; }
    }

}