using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Web.Models.Dto.Result
{
    public class UserLoginResult
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }
    }
}
