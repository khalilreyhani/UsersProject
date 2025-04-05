using Application.Interfaces;
using Context;
using Domain.Interfaces;
using Domain.InterFaces;
using Domain.Models.User;
using Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _UserRepository;
        private IUserDetailRepository _UserDetailRepository;
        private readonly DBContext _ctx;
        public UserService(IUserRepository userRepository, IUserDetailRepository UserDetailRepository, DBContext ctx)
        {
            _UserRepository = userRepository;
            _UserDetailRepository = UserDetailRepository;
            _ctx = ctx;
        }
        public async Task<ServicesStatus> AddUserORUpdate(PersonViewModel person)
        {
            var userload = _UserRepository.Get(person.Id);
            if (userload != null&&person.Id!=0)
            {
                userload.UserName = person.UserName;
                userload.Mobile = person.Mobile;
                _UserRepository.Update(userload);
               var ud= _UserDetailRepository.GetUserDetailbyUserid(person.Id);
                //update userdetai
                return ServicesStatus.sucsuccess;

            }
            else
            {

           
            var user = new User
            {
                UserName = person.UserName,
                Mobile = person.Mobile,
                DateTimeCreateDate = DateTime.Now,
                UserAvatar = "default",
                IsActive = true,
                IsDeleted = false,
                RegisterDate = DateTime.Now,
                UserId = Guid.NewGuid()

            };
            if (person.Age == 0 && person.Sex == 2)
            {
                try
                {
                    await _UserRepository.InsertAsyncUser(user);
                    return ServicesStatus.sucsuccess;

                }
                catch (Exception ex)
                {

                    return ServicesStatus.failed;

                }
            }
            else
            {
                using var transaction = await _ctx.Database.BeginTransactionAsync();
                try
                {


                    var saveuser = _ctx.Users.Add(user);
                    await _ctx.SaveChangesAsync();

                    // 2.
                    var userDetail = new UserDetail
                    {
                        UserId = saveuser.Entity.Id,
                        age = person.Age,
                        sex = person.Sex == 1 ? true : false,
                        DateTimeCreateDate = DateTime.Now,
                        IsDeleted = false
                    };
                    _ctx.userDetails.Add(userDetail);
                    await _ctx.SaveChangesAsync();

                    // ** تأیید تراکنش **
                    await transaction.CommitAsync();

                    return ServicesStatus.sucsuccess;
                }
                catch (Exception ex)
                {
                    // ** در صورت خطا، تراکنش را Rollback کن **
                    await transaction.RollbackAsync();
                    return ServicesStatus.failed;
                }
            } 
            }
        }

        public void DeleteUser(int id)
        {
            _UserRepository.Delete(id);


        }

        public ServicesStatus EditUser(User model)
        {
            throw new NotImplementedException();
        }

        public UserListViewModel GetallUser(int pageId = 1, int id = 0, string filterUserName = "")
        {
            throw new NotImplementedException();
        }

        public UserListViewModel GetUsers(int Skip = 0, int Take = 10)
        {

            IEnumerable<User> result = _UserRepository.GetAll();

            UserListViewModel list = new UserListViewModel();

            list.count = result.Count();
            list.Users = result.OrderBy(u => u.Id).Skip(Skip).Take(Take).ToList();

            return list;

        }

        public User GetUserbyId(string id)
        {
            throw new NotImplementedException();
        }

        public User GetUserbyintId(int id)
        {
            throw new NotImplementedException();
        }

        public UserDetail GetUserDetail(int userid)
        {
            return _UserDetailRepository.GetUserDetailbyUserid(userid);
        }

        public PersonViewModel GetPerson(int id)
        {
            PersonViewModel model = new PersonViewModel();
            var user = _UserRepository.Get(id);
            var userdetail = _UserDetailRepository.GetUserDetailbyUserid(id);

            model.UserName = user.UserName;
            model.Mobile = user.Mobile;
            if (userdetail != null)
            {
                model.Age = userdetail.age;
                model.Sex = userdetail.sex == true ? 1 : 0;
            }


            return model;
        }
    }
}
