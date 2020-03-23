namespace LaboratorEF_StudiiDeCaz
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BusinessContext : DbContext
    {
        public DbSet<Business> Businesses { get; set; }
        public BusinessContext() : base("name=BusinessContext") { }


    }
}