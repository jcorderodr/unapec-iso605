using System.Collections.Generic;
using System.Data.Entity.Migrations;
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

        public IEnumerable<Catalog> Create(IEnumerable<Catalog> catalogs)
        {
            var lastCategoryId = GetNewId(catalogs.First().Category);
            foreach (var item in catalogs.Where(p=> p.SubCategoryId == 0))
            {
                item.SubCategoryId = ++lastCategoryId;
            }
            _context.Catalogs.AddOrUpdate(catalogs.ToArray());
            _context.SaveChanges();
            return catalogs;
        }

        public IEnumerable<Catalog> Get(string category)
        {
            return _context.Catalogs.Where(p => p.Category == category).ToList();
        }

        public Catalog Get(string category, int subCategoryId)
        {
            return _context.Catalogs.SingleOrDefault(p => p.Category == category && p.SubCategoryId == subCategoryId);
        }

        private int GetNewId(string category)
        {
            return _context.Catalogs.Any(i => i.Category == category) ?
                _context.Catalogs.Where(i => i.Category == category).Max(p => p.SubCategoryId) : 0;
        }

    }
}
