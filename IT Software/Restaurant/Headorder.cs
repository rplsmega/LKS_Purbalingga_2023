//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurant
{
    using System;
    using System.Collections.Generic;
    
    public partial class Headorder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Headorder()
        {
            this.Detailorders = new HashSet<Detailorder>();
        }
    
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public int MemberID { get; set; }
        public System.DateTime Date { get; set; }
        public string Payment { get; set; }
        public string Bank { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Detailorder> Detailorders { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Member Member { get; set; }
    }
}
