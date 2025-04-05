using Context;
using Domain.Interfaces;
using Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class UserDetailRepository : IUserDetailRepository
    {
        private readonly DBContext _ctx;
        public UserDetailRepository(DBContext ctx)
        {
            this._ctx = ctx;
        }


        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public UserDetail Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDetail> GetAll(Expression<Func<UserDetail, bool>> where = null)
        {
            throw new NotImplementedException();
        }

        public UserDetail GetUserDetailbyUserid(int id)
        {
            

            try
            {
                return _ctx.userDetails.FirstOrDefault(x => x.UserId == id);
            }
            catch
            {
                return null;
            }
        }

        public void Insert(UserDetail entity)
        {
            throw new NotImplementedException();
        }

        public bool IsExist(int Id)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(UserDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}
