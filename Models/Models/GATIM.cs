//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GATIM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GATIM()
        {
            this.POROSI_ITEM = new HashSet<POROSI_ITEM>();
        }
    
        public int gatim_id { get; set; }
        public string emriGatimit { get; set; }
        public string pershkrimi { get; set; }
        public decimal cmimi { get; set; }
        public bool disponueshmeria { get; set; }
        public string foto { get; set; }
        public System.DateTime datakrijimit { get; set; }
        public Nullable<System.DateTime> datamodifikimit { get; set; }
        public int createdBy { get; set; }
        public Nullable<int> modifiedBy { get; set; }
        public int kategori_id { get; set; }
    
        public virtual PERDORUE PERDORUE { get; set; }
        public virtual PERDORUE PERDORUE1 { get; set; }
        public virtual KATEGORI KATEGORI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POROSI_ITEM> POROSI_ITEM { get; set; }
    }
}
