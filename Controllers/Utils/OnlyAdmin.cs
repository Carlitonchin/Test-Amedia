using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Controllers.Utils
{
    public class OnlyAdmin : Controller, IOnlyAdmin
    {

        private IRoleController roleController;
        public OnlyAdmin(IRoleController roleController) 
        {
            this.roleController = roleController;
        }
        public async Task<bool> Can() 
        {
            byte[] bytes = null;
            HttpContext.Session.TryGetValue("user", out bytes);
            if(bytes == null)
                return false;

            int idUser = Utils.TransformBytesToInt(bytes);
            string role = await roleController.Role(idUser);
            if (role == null || role != "Administrador")
                return false;

            return true;
        }
    }
}
