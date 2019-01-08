using Core.Web.Migrations;
using Core.Web.Models.Entities;

namespace Core.Web.Repositories
{
    public interface IUserRepository : IGenericRepository<Customer>
    {
    }

    public class UserRepository : GenericRepository<Customer>, IUserRepository
    {
        public UserRepository(CoreDbContext dbContext) : base(dbContext)
        {

        }
    }
}