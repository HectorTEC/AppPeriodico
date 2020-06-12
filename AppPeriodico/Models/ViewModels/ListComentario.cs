using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AppPeriodico.Models.ViewModels
{
    public class ListComentario
    {
        [DisplayName("Id. del comentario")]
        public int idComentario { get; set; }

        [DisplayName("Descripcion")]
        public string Descripcion { get; set; }

        [DisplayName("Estado")]
        public bool Estatus { get; set; }
    }
}