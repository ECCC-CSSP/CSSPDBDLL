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
    
    public partial class Infrastructure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Infrastructure()
        {
            this.InfrastructureLanguages = new HashSet<InfrastructureLanguage>();
        }
    
        public int InfrastructureID { get; set; }
        public int InfrastructureTVItemID { get; set; }
        public Nullable<int> PrismID { get; set; }
        public Nullable<int> TPID { get; set; }
        public Nullable<int> LSID { get; set; }
        public Nullable<int> SiteID { get; set; }
        public Nullable<int> Site { get; set; }
        public string InfrastructureCategory { get; set; }
        public Nullable<int> InfrastructureType { get; set; }
        public Nullable<int> FacilityType { get; set; }
        public Nullable<bool> IsMechanicallyAerated { get; set; }
        public Nullable<int> NumberOfCells { get; set; }
        public Nullable<int> NumberOfAeratedCells { get; set; }
        public Nullable<int> AerationType { get; set; }
        public Nullable<int> PreliminaryTreatmentType { get; set; }
        public Nullable<int> PrimaryTreatmentType { get; set; }
        public Nullable<int> SecondaryTreatmentType { get; set; }
        public Nullable<int> TertiaryTreatmentType { get; set; }
        public Nullable<int> TreatmentType { get; set; }
        public Nullable<int> DisinfectionType { get; set; }
        public Nullable<int> CollectionSystemType { get; set; }
        public Nullable<int> AlarmSystemType { get; set; }
        public Nullable<double> DesignFlow_m3_day { get; set; }
        public Nullable<double> AverageFlow_m3_day { get; set; }
        public Nullable<double> PeakFlow_m3_day { get; set; }
        public Nullable<int> PopServed { get; set; }
        public Nullable<bool> CanOverflow { get; set; }
        public Nullable<double> PercFlowOfTotal { get; set; }
        public Nullable<double> TimeOffset_hour { get; set; }
        public string TempCatchAllRemoveLater { get; set; }
        public Nullable<double> AverageDepth_m { get; set; }
        public Nullable<int> NumberOfPorts { get; set; }
        public Nullable<double> PortDiameter_m { get; set; }
        public Nullable<double> PortSpacing_m { get; set; }
        public Nullable<double> PortElevation_m { get; set; }
        public Nullable<double> VerticalAngle_deg { get; set; }
        public Nullable<double> HorizontalAngle_deg { get; set; }
        public Nullable<double> DecayRate_per_day { get; set; }
        public Nullable<double> NearFieldVelocity_m_s { get; set; }
        public Nullable<double> FarFieldVelocity_m_s { get; set; }
        public Nullable<double> ReceivingWaterSalinity_PSU { get; set; }
        public Nullable<double> ReceivingWaterTemperature_C { get; set; }
        public Nullable<int> ReceivingWater_MPN_per_100ml { get; set; }
        public Nullable<double> DistanceFromShore_m { get; set; }
        public Nullable<int> SeeOtherTVItemID { get; set; }
        public Nullable<int> CivicAddressTVItemID { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InfrastructureLanguage> InfrastructureLanguages { get; set; }
        public virtual TVItem TVItem { get; set; }
        public virtual TVItem TVItem1 { get; set; }
        public virtual TVItem TVItem2 { get; set; }
    }
}
