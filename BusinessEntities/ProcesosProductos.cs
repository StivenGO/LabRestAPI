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
    
    public partial class ProcesosProductos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProcesosProductos()
        {
            this.TransicionesOrdenes = new HashSet<TransicionesOrdenes>();
        }
    
        public int IdProcesoProducto { get; set; }
        public int FkIdProceso { get; set; }
        public int FkIdProducto { get; set; }
    
        public virtual Procesos Procesos { get; set; }
        public virtual Productos Productos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TransicionesOrdenes> TransicionesOrdenes { get; set; }
    }
}