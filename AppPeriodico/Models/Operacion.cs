//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AppPeriodico.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Operacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Operacion()
        {
            this.RolOperacion = new HashSet<RolOperacion>();
        }
    
        public int idOperacion { get; set; }
        public string Nombre { get; set; }
        public int idModulo { get; set; }
        public bool Estatus { get; set; }
    
        public virtual Modulo Modulo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RolOperacion> RolOperacion { get; set; }
    }
}
