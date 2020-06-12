using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AppPeriodico.Models.ViewModels
{
    public class ListPublicacionViewModels
    {
        [DisplayName("Id. de la Publicación")]
        public int idPublicacion { get; set; }

        [DisplayName("Nombre de la Publicación")]
        public string NombrePublicacion { get; set; }

        [DisplayName("Fecha de la Publicación")]
        public Nullable<System.DateTime> FechaPublicacion { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }

        [DisplayName("Estado")]
        public bool estatus { get; set; }

        [DisplayName("Id. de la Categoría")]
        public Nullable<int> idCategoria { get; set; }

        [DisplayName("Id. del Usuario")]
        public Nullable<int> idUsuario { get; set; }

        [DisplayName("Id del Tipo de Publicacion")]
        public Nullable<int> idTipoPublicacion{ get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual TipoPublicacion TipoPublicacion { get; set; }
    }
}