using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Extensions;
using Core.Web.Migrations;
using Core.Web.Models.Entities;
using Core.Web.Models.ModelsHelper;

namespace Core.Web.Repositories
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> Filter(IEnumerable<Filters> filters);
    }
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(CoreDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<ProductCategory> Filter(IEnumerable<Filters> filters)
        {
            return DbContext.Set<ProductCategory>().AddFilter(filters);
        }
    }
}
