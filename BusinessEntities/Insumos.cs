//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BusinessEntities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Insumos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Insumos()
        {
            this.InsumosCompras = new HashSet<InsumosCompras>();
            this.InsumosProcesos = new HashSet<InsumosProcesos>();
        }
    
        public int IdInsumos { get; set; }
        public string Insumo { get; set; }
        public string Descripcion { get; set; }
        public string Unidad { get; set; }
        public System.DateTime FechaInicioVigencia { get; set; }
        public Nullable<System.DateTime> FechaCierreVigencia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InsumosCompras> InsumosCompras { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InsumosProcesos> InsumosProcesos { get; set; }
    }
}
