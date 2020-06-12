using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppPeriodico.Models.ViewModels
{
    public class PublicacionViewModel
    {
        public int idPublicacion { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre Publicacion")]
        public string Descripcion { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Descripcion")]


        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaPublicacion { get; set; }

    }
}
