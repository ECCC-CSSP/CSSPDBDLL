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
    
    public partial class PolSourceSiteEffect
    {
        public int PolSourceSiteEffectID { get; set; }
        public int PolSourceSiteTVItemID { get; set; }
        public int MWQMSiteTVItemID { get; set; }
        public string PolSourceSiteEffectTermIDs { get; set; }
        public string Comments { get; set; }
        public Nullable<int> AnalysisDocumentTVItemID { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    
        public virtual TVItem TVItem { get; set; }
        public virtual TVItem TVItem1 { get; set; }
        public virtual TVItem TVItem2 { get; set; }
    }
}
