namespace EF_Studii_de_caz
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using EF_Studii_de_caz.Classes;

    public class ModelSelfReferences : DbContext
    {
        
        public ModelSelfReferences()
            : base("name=ModelSelfReferences")
        {
        }


        public virtual DbSet<SelfReference> MyEntities { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SelfReference>()
            .HasMany(m => m.References)
            .WithOptional(m => m.ParentSelfReference);
        }
    }

  
}

 