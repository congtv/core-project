using Core.Web.Migrations;
using Core.Web.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Web.Repositories
{
    public interface IUserRepository : IGenericRepository<Customer>
    {
    }

    public class UserRepository : GenericRepository<Customer>
    {
        public UserRepository(CoreDbContext dbContext) : base(dbContext)
        {

        }
        public override void Update(Customer entity)
        {
            base.Update(entity);
            DbContext.Set<IdentityUser>().Update(entity.IdentityUser);
        }
        public override void Delete(Customer entity)
        {
            base.Delete(entity);
            DbContext.Set<IdentityUser>().Remove(entity.IdentityUser);
        }
    }
}