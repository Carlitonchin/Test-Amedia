using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Controllers.Utils
{
    public static class Utils
    {
        public static int TransformBytesToInt(byte[] bytes) 
        {
            return BitConverter.ToInt32(bytes,0);
        }
    }
}
