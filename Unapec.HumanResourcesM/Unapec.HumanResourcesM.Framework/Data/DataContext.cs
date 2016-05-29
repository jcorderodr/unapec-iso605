using System.Data.Entity;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Framework.Data
{



    public class DataContext : DbContext
    {
        public DataContext()
            :base("SqlConnection")
        {
            Database.SetInitializer(new CustomDataInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<User>().HasMany(p => p.Permissions);

        }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantDetail> ApplicantDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PersonLinkedDetail> PersonLinkedDetails { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> JobOffers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseQuorum> CourseQuorums { get; set; }

    }
}
