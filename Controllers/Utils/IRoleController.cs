using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_Crud_Carlos_Arrieta.Models;
using Test_Crud_Carlos_Arrieta.Data;

namespace Test_Crud_Carlos_Arrieta.Controllers.Utils
{
    public interface IRoleController
    {
        public Task<string> Role(tUsers user);
        public Task<string> Role(int userId);
    }
}
