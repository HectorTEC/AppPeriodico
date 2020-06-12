using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace AppPeriodico.Models.ViewModels
{
    public class ListUsuarioViewModels
    {
        [DisplayName("Id. del Usuario")]
        public int idUsuario { get; set; }

        [DisplayName("Nombre de Usuario")]
        public string NombreUsuario { get; set; }

        [DisplayName("Contraseña del Usuario")]
        public string Contraseña { get; set; }

        [DisplayName("Estado")]
        public bool estatus { get; set; }

        [DisplayName("Id. Tipo de Usuario")]
        public Nullable<int> idTipoUsuario { get; set; }

        [DisplayName("Id del Comentario")]
        public Nullable<int> idComentario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Publicacion> Publicacion { get; set; }


        public virtual TipoUsuario TipoUsuario { get; set; }

        public virtual Comentario Comentario { get; set; }
    }
}