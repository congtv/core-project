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
        IEnumerable<ProductCategory> GetAll();
        ProductCategory GetById(int id);
        void Add(ProductCategory productCategory);
        void Update(ProductCategory productCategory);
        void Delete(int id);
        bool SaveChange();
    }
    public class ProductCategoryService : IProductCategoryService
    {
        IProductCategoryRepository productCategoryRepository;
        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }

        public void Add(ProductCategory productCategory)
        {
            this.productCategoryRepository.Add(productCategory);
        }

        public void Delete(int id)
        {
            var productCategory = this.productCategoryRepository.Search(x => x.ID == id).FirstOrDefault();
            if (productCategory == null)
                throw new Exception($"{nameof(productCategory)} not found!");
            this.productCategoryRepository.Delete(productCategory);
        }

        public IEnumerable<ProductCategory> Filter(IEnumerable<Filters> filters)
        {
            return productCategoryRepository.Filter(filters);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return this.productCategoryRepository.GetAll();
        }

        public ProductCategory GetById(int id)
        {
            return this.productCategoryRepository.Search(x => x.ID == id).FirstOrDefault();
        }

        public bool SaveChange()
        {
            return this.productCategoryRepository.SaveChanges() > 0;
        }

        public void Update(ProductCategory productCategory)
        {

            this.productCategoryRepository.Update(productCategory);
        }
    }
}
