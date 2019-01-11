using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Migrations;
using Core.Web.Models.Entities;

namespace Core.Web.Repositories
{
    public interface IProductTagRepository : IGenericRepository<ProductTag>
    {

    }
    public class ProductTagRepository : GenericRepository<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(CoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
