using System.Collections.Generic;
using System.Linq;
using Unapec.HumanResourcesM.Framework.Data;
using Unapec.HumanResourcesM.Framework.Entities;

namespace Unapec.HumanResourcesM.Framework.Services
{
    public class CatalogService
    {
        private readonly DataContext _context;

        public CatalogService()
        {
            _context = new DataContext();
        }

        public IEnumerable<Catalog> Get(string category)
        {
            return _context.Catalogs.Where(p => p.Category == category).ToList();
        }

        public Catalog Get(string category, int subCategoryId)
        {
            return _context.Catalogs.SingleOrDefault(p => p.Category == category && p.SubCategoryId == subCategoryId);
        }

    }
}
