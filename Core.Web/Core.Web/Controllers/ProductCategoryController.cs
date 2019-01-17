using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Core.Web.Models.Entities;
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
        IProductCategoryRepository productCategoryRepository;
        public ProductCategoryController(IProductCategoryService productCategoryService, IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryService = productCategoryService;
            this.productCategoryRepository = productCategoryRepository;
        }

        [Route("getall")]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var list = productCategoryService.GetAll();
            return new OkObjectResult(list);
        }
    }
}
