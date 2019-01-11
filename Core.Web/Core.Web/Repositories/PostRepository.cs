using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Migrations;
using Core.Web.Models.Entities;

namespace Core.Web.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {

    }
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(CoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
