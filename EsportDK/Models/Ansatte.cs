//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EsportDK.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ansatte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ansatte()
        {
            this.Turneringers = new HashSet<Turneringer>();
        }
    
        public int ID { get; set; }
        public string Fornavn { get; set; }
        public string Efternavn { get; set; }
        public string Telefon { get; set; }
        public decimal Løn { get; set; }
        public string Jobtype { get; set; }
        public string DommerLevel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Turneringer> Turneringers { get; set; }
    }
}
