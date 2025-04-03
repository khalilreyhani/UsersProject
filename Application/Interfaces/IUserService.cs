using Domain.Models.User;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
{


        public UserListViewModel GetallUser(int pageId = 1, int id = 0, string filterUserName = "");

        public ServicesStatus AddUser(User user);

        public User GetUserbyId(string id);
        public User GetUserbyintId(int id);

        public ServicesStatus EditUser(User model);

        public void DeleteUser(int id);

    }
}
