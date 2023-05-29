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
    
    public partial class MWQMRun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MWQMRun()
        {
            this.MWQMRunLanguages = new HashSet<MWQMRunLanguage>();
        }
    
        public int MWQMRunID { get; set; }
        public int DBCommand { get; set; }
        public int SubsectorTVItemID { get; set; }
        public int MWQMRunTVItemID { get; set; }
        public int RunSampleType { get; set; }
        public System.DateTime DateTime_Local { get; set; }
        public int RunNumber { get; set; }
        public Nullable<System.DateTime> StartDateTime_Local { get; set; }
        public Nullable<System.DateTime> EndDateTime_Local { get; set; }
        public Nullable<System.DateTime> LabReceivedDateTime_Local { get; set; }
        public Nullable<double> TemperatureControl1_C { get; set; }
        public Nullable<double> TemperatureControl2_C { get; set; }
        public Nullable<int> SeaStateAtStart_BeaufortScale { get; set; }
        public Nullable<int> SeaStateAtEnd_BeaufortScale { get; set; }
        public Nullable<double> WaterLevelAtBrook_m { get; set; }
        public Nullable<double> WaveHightAtStart_m { get; set; }
        public Nullable<double> WaveHightAtEnd_m { get; set; }
        public string SampleCrewInitials { get; set; }
        public Nullable<int> AnalyzeMethod { get; set; }
        public Nullable<int> SampleMatrix { get; set; }
        public Nullable<int> Laboratory { get; set; }
        public Nullable<int> SampleStatus { get; set; }
        public Nullable<int> LabSampleApprovalContactTVItemID { get; set; }
        public Nullable<System.DateTime> LabAnalyzeBath1IncubationStartDateTime_Local { get; set; }
        public Nullable<System.DateTime> LabAnalyzeBath2IncubationStartDateTime_Local { get; set; }
        public Nullable<System.DateTime> LabAnalyzeBath3IncubationStartDateTime_Local { get; set; }
        public Nullable<System.DateTime> LabRunSampleApprovalDateTime_Local { get; set; }
        public Nullable<int> Tide_Start { get; set; }
        public Nullable<int> Tide_End { get; set; }
        public Nullable<double> RainDay0_mm { get; set; }
        public Nullable<double> RainDay1_mm { get; set; }
        public Nullable<double> RainDay2_mm { get; set; }
        public Nullable<double> RainDay3_mm { get; set; }
        public Nullable<double> RainDay4_mm { get; set; }
        public Nullable<double> RainDay5_mm { get; set; }
        public Nullable<double> RainDay6_mm { get; set; }
        public Nullable<double> RainDay7_mm { get; set; }
        public Nullable<double> RainDay8_mm { get; set; }
        public Nullable<double> RainDay9_mm { get; set; }
        public Nullable<double> RainDay10_mm { get; set; }
        public Nullable<double> Tide_h0_m { get; set; }
        public Nullable<double> Tide_h1_m { get; set; }
        public Nullable<double> Tide_h2_m { get; set; }
        public Nullable<double> Tide_h3_m { get; set; }
        public Nullable<double> Tide_h4_m { get; set; }
        public Nullable<double> Tide_h5_m { get; set; }
        public Nullable<double> Tide_h6_m { get; set; }
        public Nullable<double> Tide_h7_m { get; set; }
        public Nullable<double> Tide_h8_m { get; set; }
        public Nullable<double> Tide_h9_m { get; set; }
        public Nullable<double> Tide_h10_m { get; set; }
        public Nullable<double> Tide_h11_m { get; set; }
        public Nullable<double> Tide_h12_m { get; set; }
        public Nullable<double> Tide_h13_m { get; set; }
        public Nullable<double> Tide_h14_m { get; set; }
        public Nullable<double> Tide_h15_m { get; set; }
        public Nullable<double> Tide_h16_m { get; set; }
        public Nullable<double> Tide_h17_m { get; set; }
        public Nullable<double> Tide_h18_m { get; set; }
        public Nullable<double> Tide_h19_m { get; set; }
        public Nullable<double> Tide_h20_m { get; set; }
        public Nullable<double> Tide_h21_m { get; set; }
        public Nullable<double> Tide_h22_m { get; set; }
        public Nullable<double> Tide_h23_m { get; set; }
        public Nullable<double> Tide_h24_m { get; set; }
        public Nullable<double> Tide_h25_m { get; set; }
        public Nullable<double> Tide_h26_m { get; set; }
        public Nullable<double> Tide_h27_m { get; set; }
        public Nullable<double> Tide_h28_m { get; set; }
        public Nullable<double> Tide_h29_m { get; set; }
        public Nullable<double> Tide_h30_m { get; set; }
        public Nullable<int> Tide_Start_From_WebTide { get; set; }
        public Nullable<int> Tide_End_From_WebTide { get; set; }
        public Nullable<bool> RemoveFromStat { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MWQMRunLanguage> MWQMRunLanguages { get; set; }
        public virtual TVItem TVItem { get; set; }
        public virtual TVItem TVItem1 { get; set; }
        public virtual TVItem TVItem2 { get; set; }
    }
}
