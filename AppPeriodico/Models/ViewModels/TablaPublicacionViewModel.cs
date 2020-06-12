using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppPeriodico.Models.ViewModels
{
    public class TablaPublicacionViewModel
    {
        public int idPublicacion { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        public int idCategoria { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "idCategoria")]
        public string NombrePublicacion { get; set; }
        [Required]
        [StringLength(50)]

        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        public int idTipoPublicacion { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "idTipoPublicacion")]

        
        public string Correo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de nacimiento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaPublicacion { get; set; }
    }
}