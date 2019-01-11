using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Migrations;
using Core.Web.Models.Entities;

namespace Core.Web.Repositories
{
    public interface IPostCategoryRepository : IGenericRepository<PostCategory>
    {

    }
    public class PostCategoryRepository : GenericRepository<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(CoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
