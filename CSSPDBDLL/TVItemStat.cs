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
    
    public partial class TVItemStat
    {
        public int TVItemStatID { get; set; }
        public int DBCommand { get; set; }
        public int TVItemID { get; set; }
        public int TVType { get; set; }
        public int ChildCount { get; set; }
        public System.DateTime LastUpdateDate_UTC { get; set; }
        public int LastUpdateContactTVItemID { get; set; }
    
        public virtual TVItem TVItem { get; set; }
    }
}
