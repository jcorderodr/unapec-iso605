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
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 1, Value = "Nivel Básico" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 2, Value = "Nivel Medio / Bachiller" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 3, Value = "Estudiante Universitario" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 4, Value = "Universitario" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 5, Value = "Post-Grado" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 6, Value = "Maestría" },
                    new Catalog { Category = "GRADE_LVL", SubCategoryId = 7, Value = "Doctorado" },

                    new Catalog { Category = "LANGUAGE", SubCategoryId = 1, Value = "Inglés" },
                    new Catalog { Category = "LANGUAGE", SubCategoryId = 2, Value = "Francés" },
                    new Catalog { Category = "LANGUAGE", SubCategoryId = 3, Value = "Alemán" },
                    new Catalog { Category = "LANGUAGE", SubCategoryId = 4, Value = "Chino" },

                    new Catalog { Category = "LANG_LVL", SubCategoryId = 1, Value = "Básico" },
                    new Catalog { Category = "LANG_LVL", SubCategoryId = 2, Value = "Medio" },
                    new Catalog { Category = "LANG_LVL", SubCategoryId = 3, Value = "Nativo" },
                };
            context.Catalogs.AddRange(catalogs);

            context.SaveChanges();
        }
    }
}
