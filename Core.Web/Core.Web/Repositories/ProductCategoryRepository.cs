using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Migrations;
using Core.Web.Models.Entities;

namespace Core.Web.Repositories
{
    public interface IProductCategoryRepository : IGenericRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> Filter(string filters);
    }
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(CoreDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<ProductCategory> Filter(string filters)
        {

        }
    }
}
