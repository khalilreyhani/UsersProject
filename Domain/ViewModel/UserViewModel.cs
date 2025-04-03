using Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModel
{
    public class UserViewModel
{
}
    public class UserListViewModel
    {
        public int count { get; set; }
        public List<User> Users { get; set; }

        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public enum ServicesStatus
    {
        sucsuccess = 1,
        failed = 0,
    }
}
