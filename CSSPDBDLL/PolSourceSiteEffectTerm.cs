//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CSSPDBDLL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PolSourceSiteEffectTerm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PolSourceSiteEffectTerm()
        {
            this.PolSourceSiteEffectTerms1 = new HashSet<PolSourceSiteEffectTerm>();
        }
    
        public int PolSourceSiteEffectTermID { get; set; }
        public bool IsGroup { get; set; }
        public Nullable<int> UnderGroupID { get; set; }
        public string EffectTermEN { get; set; }
        public string EffectTermFR { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PolSourceSiteEffectTerm> PolSourceSiteEffectTerms1 { get; set; }
        public virtual PolSourceSiteEffectTerm PolSourceSiteEffectTerm1 { get; set; }
    }
}
