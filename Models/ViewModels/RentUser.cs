using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_Crud_Carlos_Arrieta.Models.ViewModels
{
    public class RentUser
    {
        public tPelicula film { get; set; }
        public tUsers user { get; set; }
        public int userId { get; set; }

        public RentUser(tPelicula film, tUsers user, int userId) 
        {
            this.film = film;
            this.user = user;
            this.userId = userId;
        }
    }
}
