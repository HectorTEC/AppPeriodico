using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AppPeriodico.Models.ViewModels
{
    public class ListCategoriaViewModels
    {
        [DisplayName("Id. de la Categoría")]
        public int idCategoria { get; set; }

        [DisplayName("Nombre de la Categoría")]
        public string NombreCategoria { get; set; }

        [DisplayName("Estado")]
        public bool Estatus { get; set; }
    }
}