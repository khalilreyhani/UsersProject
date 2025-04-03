using Domain.Interfaces;
using Domain.Models;
using Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.InterFaces
{


    public interface IUserRepository:IGneralRepository<User>
    {
        public  Task InsertAsyncUser(Domain.Models.User.User entity);
        

        public User GetByUserId(string userId);



    }


}
