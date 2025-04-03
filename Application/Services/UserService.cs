using Application.Interfaces;
using Domain.Models.User;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        public ServicesStatus AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public ServicesStatus EditUser(User model)
        {
            throw new NotImplementedException();
        }

        public UserListViewModel GetallUser(int pageId = 1, int id = 0, string filterUserName = "")
        {
            throw new NotImplementedException();
        }

        public User GetUserbyId(string id)
        {
            throw new NotImplementedException();
        }

        public User GetUserbyintId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
