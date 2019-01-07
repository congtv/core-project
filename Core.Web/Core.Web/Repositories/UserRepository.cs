using Core.Web.Migrations;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Repositories
{
    public interface IUserRepository : IGenericRepository<IdentityUser>
    {

    }
    public class UserRepository : GenericRepository<IdentityUser>,IUserRepository
    {

    }
}
