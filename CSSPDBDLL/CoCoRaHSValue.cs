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
    
    public partial class CoCoRaHSValue
    {
        public int CoCoRaHSValueID { get; set; }
        public int CoCoRaHSSiteID { get; set; }
        public System.DateTime ObservationDateAndTime { get; set; }
        public Nullable<double> TotalPrecipAmt { get; set; }
        public Nullable<double> NewSnowDepth { get; set; }
        public Nullable<double> NewSnowSWE { get; set; }
        public Nullable<double> TotalSnowDepth { get; set; }
        public Nullable<double> TotalSnowSWE { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    
        public virtual CoCoRaHSSite CoCoRaHSSite { get; set; }
    }
}
