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
    
    public partial class TideSite
    {
        public int TideSiteID { get; set; }
        public int DBCommand { get; set; }
        public int TideSiteTVItemID { get; set; }
        public string TideSiteName { get; set; }
        public string Province { get; set; }
        public int sid { get; set; }
        public int Zone { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    
        public virtual TVItem TVItem { get; set; }
    }
}
