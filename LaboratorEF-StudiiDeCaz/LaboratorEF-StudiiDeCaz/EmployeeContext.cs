namespace LaboratorEF_StudiiDeCaz
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
            .Map<FullTimeEmployee>(m => m.Requires("EmployeeType")
            .HasValue(1))
            .Map<HourlyEmployee>(m => m.Requires("EmployeeType")
            .HasValue(2));
        }



    }


}