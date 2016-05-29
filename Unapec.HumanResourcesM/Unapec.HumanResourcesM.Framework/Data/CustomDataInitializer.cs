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
                    new EmployeePosition { Department = gg, Name = "Secretario General", Description = "Persona encargada de gestionar las reuniones y agendas de la alta gerencia.", PositionMaxSalary = 240000.00M, PositionMinSalary = 295000.00M },
                    new EmployeePosition { Department = gg, Name = "Gerente de IT", Description = "Persona encargada de dirigir el área de Tecnología de la Información.", PositionMaxSalary = 420000.00M, PositionMinSalary = 360000.00M },
                    new EmployeePosition { Department = gg, Name = "Gerente de Desarrollo de Sistemas", Description = "Persona encargada de dirigir los desarrollos e implementaciones de los sistemas.", PositionMaxSalary = 360000.00M, PositionMinSalary = 360000.00M },
                    new EmployeePosition { Department = gg, Name = "Gerente Contabilidad", Description = "Persona encargada de gestionar la contabilidad de la institución.", PositionMaxSalary = 420000.00M, PositionMinSalary = 360000.00M },
                    new EmployeePosition { Department = gg, Name = "Gerente de Gestión Humana", Description = "Persona encargada de gestionar los recursos humanos de la institución.", PositionMaxSalary = 420000.00M, PositionMinSalary = 360000.00M },
                    new EmployeePosition { Department = finance, Name = "Supervisor Financiero", Description = "", PositionMaxSalary = 034750.000M, PositionMinSalary =  208500.00M},
                    new EmployeePosition { Department = finance, Name = "Auxiliar de Contabilidad", Description = "Se encarga de analizar y procesar los registros contables de la institución.", PositionMaxSalary = 018000.000M, PositionMinSalary =  025000.00M},
                    new EmployeePosition { Department = it, Name = "Encargado de Desarrollo", Description = "Supervisa, Coordina y Administra el Departamento de Desarrollo de Sistemas de la institución", PositionMaxSalary = 140000.00M, PositionMinSalary = 110000.00M },
                    new EmployeePosition { Department = it, Name = "Analista Desarrollador", Description = "Analiza, diseña y da mantenimiento a los sistemas de la insticución.", PositionMaxSalary = 062000.00M, PositionMinSalary = 034000.00M },
                    new EmployeePosition { Department = rrhh, Name = "Encargado de Capacitación", Description = "Se encarga de coordinar las capacitaciones de la institución.", PositionMaxSalary = 062000.00M, PositionMinSalary = 034000.000M },
                    new EmployeePosition { Department = rrhh, Name = "Analista de Contrataciones", Description = "Se encarga de gestionar los posibles nuevos empleados de la institución.", PositionMaxSalary = 050000.00M, PositionMinSalary = 028000.00M },
                    new EmployeePosition { Department = security, Name = "Encargado de Seguridad Física", Description = "Se encarga de coordinar el personal de seguridad física.", PositionMaxSalary = 030000.00M, PositionMinSalary = 035500.00M },
                    new EmployeePosition { Department = security, Name = "Personal de Protección Física", Description = "Personal que procura mediante revisiones el cumplimiento de los estándares de seguridad requeridos por la institución.", PositionMaxSalary = 018000.00M, PositionMinSalary = 027500.00M },
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
