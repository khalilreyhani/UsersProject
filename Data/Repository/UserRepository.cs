﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    using Context;
    using Domain.Interfaces;
    using Domain.InterFaces;
    using Domain.Models.User;
    using Microsoft.EntityFrameworkCore;
    using System.Data;
    using System.Linq.Expressions;

    public class UserRepository : IUserRepository
    {
        private readonly DBContext _ctx;
        public UserRepository(DBContext ctx)
        {
            this._ctx = ctx;
        }

       

        public void Delete(int Id)
        {
            var user = Get(Id);
            user.IsDeleted = true;
            Update(user);
        }

        public Domain.Models.User.User Get(int Id)
        {
            try
            {
                var user= _ctx.Users.FirstOrDefault(x => x.Id == Id);

                if (user != null)
                {
                    return user;
                }

                else {
                    User model = new User()
                    {
                        Mobile = "delete user",
                        UserName = "delete user"
                   ,
                    };

                    return model;

                }

            }
            catch
            {
                User model = new User()
                {
                    Mobile = "delete user",
                    UserName = "delete user"
                    ,
                };

                return model;

            }
        }

        public IEnumerable<Domain.Models.User.User> GetAll(Expression<Func<Domain.Models.User.User, bool>> where = null)
        {
            return _ctx.Users;
        }

        public Domain.Models.User.User GetByUserId(string userId)
        {
           return _ctx.Users.Where(x => x.UserId.ToString() == userId).FirstOrDefault();
        }

    


        public void Insert(Domain.Models.User.User entity)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsyncUser(Domain.Models.User.User entity)
        {
           
                    // عملیات اول
                     _ctx.Users.Add(entity);
                    await _ctx.SaveChangesAsync();

                   
                    await _ctx.SaveChangesAsync();


        

          
        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }



        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }

        public void Update(Domain.Models.User.User entity)
        {
            _ctx.Users.Update(entity);
            SaveChanges();      
        }


     
    }

}
