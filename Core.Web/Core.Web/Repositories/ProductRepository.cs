using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Migrations;
using Core.Web.Models.Entities;

namespace Core.Web.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {

    }
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(CoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
