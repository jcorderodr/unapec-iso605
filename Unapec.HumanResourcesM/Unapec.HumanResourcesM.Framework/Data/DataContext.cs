using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unapec.HumanResourcesM.Framework.Data
{

    class CustomDataInitializer: CreateDatabaseIfNotExists<DataContext>
    {


        protected override void Seed(DataContext context)
        {
            base.Seed(context);

            if (!context.Catalogs.DefaultIfEmpty().Any())
            {
                var catalogs = new List<Catalog>
                {
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 1, Value = "Nivel Básico" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 2, Value = "Nivel Medio / Bachiller" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 3, Value = "Estudiante Universitario" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 4, Value = "Universitario" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 5, Value = "Post-Grado" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 6, Value = "Maestría" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 7, Value = "Doctorado" }
                };

                context.Set<Catalog>().AddRange(catalogs);
            }
            context.SaveChanges();
        }
    }

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
            
            modelBuilder.Entity<User>().HasMany(p => p.Roles);

        }

        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantDetail> ApplicantDetails { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> JobOffers { get; set; }
        public DbSet<EmployeePosition> EmployeePositions { get; set; }

    }
}
