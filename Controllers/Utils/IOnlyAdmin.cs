using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Controllers.Utils
{
    public interface IOnlyAdmin
    {
        public Task<bool> Can();
    }
}
