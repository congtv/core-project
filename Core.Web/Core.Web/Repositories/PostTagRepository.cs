using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Web.Migrations;
using Core.Web.Models.Entities;

namespace Core.Web.Repositories
{
    public interface IPostTagRepository : IGenericRepository<PostTag>
    {

    }
    public class PostTagRepository : GenericRepository<PostTag>, IPostTagRepository
    {
        public PostTagRepository(CoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}
