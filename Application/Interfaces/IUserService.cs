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

        public UserListViewModel GetUsers(int Skip = 0,int Take  = 10);

        public Task<ServicesStatus> AddUserORUpdate(PersonViewModel person);

        public PersonViewModel GetPerson(int id);


        public UserDetail GetUserDetail(int userid);
        

        public ServicesStatus EditUser(User model);

        public void DeleteUser(int id);

    }
}
