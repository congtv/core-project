using Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Services
{
    public interface IUserService : IGenericService<Error>
    {

    }
    public class UserService : IUserService
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Error> GetAll()
        {
            throw new NotImplementedException();
        }

        public Error GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Error entity)
        {
            throw new NotImplementedException();
        }

        public void InsertRange(IEnumerable<Error> entities)
        {
            throw new NotImplementedException();
        }

        public void SaveChanged()
        {
            throw new NotImplementedException();
        }

        public void Update(Error entity)
        {
            throw new NotImplementedException();
        }
    }
}
