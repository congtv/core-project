using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Models.Entities;
using Core.Web.Models.ModelsHelper;
using Core.Web.Repositories;

namespace Core.Web.Services
{
    public interface IProductCategoryService
    {
        IEnumerable<ProductCategory> Filter(IEnumerable<Filters> filters);
    }
    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }
        public IEnumerable<ProductCategory> Filter(IEnumerable<Filters> filters)
        {
            return productCategoryRepository.Filter(filters);
        }
    }
}
