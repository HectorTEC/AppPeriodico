using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AppPeriodico.Models.ViewModels
{
    public class ListTipoPublicacion
    {
        [DisplayName("Id del Tipo de Publicacion")]
        public int idTipoPublicacion { get; set; }

        [DisplayName("Tipo de publicacion")]
        public string Descripcion { get; set; }

        [DisplayName("Estatus")]
        public bool Estatus { get; set; }
    }
}