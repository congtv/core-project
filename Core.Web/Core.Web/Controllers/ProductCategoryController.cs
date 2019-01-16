using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Models.ModelsHelper;
using Core.Web.Repositories;
using Core.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductCategoryController : ControllerBase
    {
        IProductCategoryService productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this.productCategoryService = productCategoryService;
        }

        [Route("getall")]
        [AllowAnonymous]
        public IActionResult GetAll(string search)
        {
            List<Filters> filters = new List<Filters>()
            {
                new Filters()
                {
                    Attribute = "Name",
                    Values = new List<string>(){ "Phao hoa" },
                    Operator = Operator.Equals
                }
            };
            var productCategories = productCategoryService.Filter(filters);
            return new OkObjectResult(productCategories);
        }
    }
}
