﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CoCoRaHSEntities : DbContext
    {
        public CoCoRaHSEntities()
            : base("name=CoCoRaHSEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CoCoRaHSSite> CoCoRaHSSites { get; set; }
        public virtual DbSet<CoCoRaHSValue> CoCoRaHSValues { get; set; }
    }
}