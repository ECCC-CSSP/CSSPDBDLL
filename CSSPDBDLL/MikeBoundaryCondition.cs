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
    
    public partial class MikeBoundaryCondition
    {
        public int MikeBoundaryConditionID { get; set; }
        public int MikeBoundaryConditionTVItemID { get; set; }
        public string MikeBoundaryConditionCode { get; set; }
        public string MikeBoundaryConditionName { get; set; }
        public double MikeBoundaryConditionLength_m { get; set; }
        public string MikeBoundaryConditionFormat { get; set; }
        public int MikeBoundaryConditionLevelOrVelocity { get; set; }
        public int WebTideDataSet { get; set; }
        public int NumberOfWebTideNodes { get; set; }
        public string WebTideDataFromStartToEndDate { get; set; }
        public int TVType { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    
        public virtual TVItem TVItem { get; set; }
    }
}
