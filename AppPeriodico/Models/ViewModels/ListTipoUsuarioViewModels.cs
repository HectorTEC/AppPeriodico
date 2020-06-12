using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AppPeriodico.Models.ViewModels
{
    public class ListTipoUsuarioViewModels
    {
        [DisplayName("Id. del Tipo de Usuario")]
        public int idTipoUsuario { get; set; }

        [DisplayName("Tipo de Usuario")]
        public string TipoUsuario1 { get; set; }

        [DisplayName("Estatus")]
        public bool Estatus { get; set; }
    }
}