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
    
    public partial class VPScenario
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VPScenario()
        {
            this.VPAmbients = new HashSet<VPAmbient>();
            this.VPResults = new HashSet<VPResult>();
            this.VPScenarioLanguages = new HashSet<VPScenarioLanguage>();
        }
    
        public int VPScenarioID { get; set; }
        public int DBCommand { get; set; }
        public int InfrastructureTVItemID { get; set; }
        public int VPScenarioStatus { get; set; }
        public bool UseAsBestEstimate { get; set; }
        public Nullable<double> EffluentFlow_m3_s { get; set; }
        public Nullable<int> EffluentConcentration_MPN_100ml { get; set; }
        public Nullable<double> FroudeNumber { get; set; }
        public Nullable<double> PortDiameter_m { get; set; }
        public Nullable<double> PortDepth_m { get; set; }
        public Nullable<double> PortElevation_m { get; set; }
        public Nullable<double> VerticalAngle_deg { get; set; }
        public Nullable<double> HorizontalAngle_deg { get; set; }
        public Nullable<int> NumberOfPorts { get; set; }
        public Nullable<double> PortSpacing_m { get; set; }
        public Nullable<double> AcuteMixZone_m { get; set; }
        public Nullable<double> ChronicMixZone_m { get; set; }
        public Nullable<double> EffluentSalinity_PSU { get; set; }
        public Nullable<double> EffluentTemperature_C { get; set; }
        public Nullable<double> EffluentVelocity_m_s { get; set; }
        public string RawResults { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    
        public virtual TVItem TVItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VPAmbient> VPAmbients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VPResult> VPResults { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VPScenarioLanguage> VPScenarioLanguages { get; set; }
    }
}
