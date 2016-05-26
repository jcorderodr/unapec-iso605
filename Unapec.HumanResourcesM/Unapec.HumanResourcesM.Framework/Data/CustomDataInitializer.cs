using System;
using System.Collections.Generic;
using System.Data.Entity;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Framework.Data
{
    public class CustomDataInitializer : CreateDatabaseIfNotExists<DataContext>
    {


        protected override void Seed(DataContext context)
        {
            base.Seed(context);

            var catalogs = new List<Catalog>
                {
                    new Catalog { Category = Catalog.GRADE_LVL, SubCategoryId = 1, Value = "Nivel Básico" },
                    new Catalog { Category = Catalog.GRADE_LVL, SubCategoryId = 2, Value = "Nivel Medio / Bachiller" },
                    new Catalog { Category = Catalog.GRADE_LVL, SubCategoryId = 3, Value = "Estudiante Universitario" },
                    new Catalog { Category = Catalog.GRADE_LVL, SubCategoryId = 4, Value = "Universitario" },
                    new Catalog { Category = Catalog.GRADE_LVL, SubCategoryId = 5, Value = "Post-Grado" },
                    new Catalog { Category = Catalog.GRADE_LVL, SubCategoryId = 6, Value = "Maestría" },
                    new Catalog { Category = Catalog.GRADE_LVL, SubCategoryId = 7, Value = "Doctorado" },

                    new Catalog { Category = Catalog.LANGUAGE, SubCategoryId = 1, Value = "Inglés" },
                    new Catalog { Category = Catalog.LANGUAGE, SubCategoryId = 2, Value = "Francés" },
                    new Catalog { Category = Catalog.LANGUAGE, SubCategoryId = 3, Value = "Alemán" },
                    new Catalog { Category = Catalog.LANGUAGE, SubCategoryId = 4, Value = "Chino" },

                    new Catalog { Category = Catalog.SKILL_LVL, SubCategoryId = 1, Value = "Básico" },
                    new Catalog { Category = Catalog.SKILL_LVL, SubCategoryId = 2, Value = "Medio" },
                    new Catalog { Category = Catalog.SKILL_LVL, SubCategoryId = 3, Value = "Nativo" },
                };
            context.Catalogs.AddRange(catalogs);

            var permissions = new List<Permission>
            {
                new Permission { Name = "Gestión de Usuarios" },
                new Permission { Name = "Gestión de Empleados" },
                new Permission { Name = "Gestión de Ofertas de Trabajo" },
            };
            context.Permissions.AddRange(permissions);

            {
                var gg = new Department { Name = "Alta Gerencia" };
                var it = new Department { Name = "Dirección de Tecnología" };
                var rrhh = new Department { Name = "Dirección de Recursos Humanos" };
                var finance = new Department { Name = "Dirección de Finanzas" };
                var security = new Department { Name = "Dirección de Seguridad Industrial" };

                var departments = new List<Department>
                {
                    gg, it, rrhh, finance, security
                };
                context.Departments.AddRange(departments);

                var employeePositions = new List<EmployeePosition>
                {
                    new EmployeePosition { Department = gg, Name = "Gerente General", Description = "Persona encargada de dirigir la institución.", PositionMaxSalary = 580000.00M, PositionMinSalary =  440000.00M},
                    new EmployeePosition { Department = gg, Name = "Secretario General", Description = "Persona encargada de gestionar las reuniones y agendas de la alta gerencia.", PositionMaxSalary = 420000.00M, PositionMinSalary = 360000.00M },
                    new EmployeePosition { Department = gg, Name = "Gerente de IT", Description = "Persona encargada de dirigir el área de Tecnología de la Información.", PositionMaxSalary = 420000.00M, PositionMinSalary = 360000.00M },
                    new EmployeePosition { Department = gg, Name = "Gerente de Desarrollo de Sistemas", Description = "Persona encargada de dirigir los desarrollos e implementaciones de los sistemas.", PositionMaxSalary = 360000.00M, PositionMinSalary = 360000.00M },
                    new EmployeePosition { Department = gg, Name = "Gerente Contabilidad", Description = "Persona encargada de gestionar la contabilidad de la institución.", PositionMaxSalary = 420000.00M, PositionMinSalary = 360000.00M },
                    new EmployeePosition { Department = gg, Name = "Gerente de Gestión Humana", Description = "Persona encargada de gestionar los recursos humanos de la institución.", PositionMaxSalary = 420000.00M, PositionMinSalary = 360000.00M },
                    new EmployeePosition { Department = finance, Name = "Supervisor Financiero", Description = "", PositionMaxSalary = 34750.00M, PositionMinSalary =  28500.00M},
                    new EmployeePosition { Department = finance, Name = "Auxiliar de Contabilidad", Description = "", PositionMaxSalary = 18000.00M, PositionMinSalary =  25000.00M},
                    new EmployeePosition { Department = it, Name = "Encargado de Desarrollo", Description = "", PositionMaxSalary = 140000.00M, PositionMinSalary = 110000.00M },
                    new EmployeePosition { Department = it, Name = "Analista Desarrollador", Description = "", PositionMaxSalary = 62000.00M, PositionMinSalary = 34000.00M },
                };
                context.EmployeePositions.AddRange(employeePositions);
            }
            
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var error in ex.EntityValidationErrors)
                {
                    foreach (var inError in error.ValidationErrors)
                    {
                        throw new Exception(inError.ErrorMessage);
                    }
                }
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException ex)
            {
                foreach (var item in ex.Entries)
                {
                    throw new Exception(ex.Message + Environment.NewLine + item.Entity, ex.InnerException);
                }
                throw new Exception(ex.Message + Environment.NewLine + ex.InnerException.Message);
            }
        }
    }
}
