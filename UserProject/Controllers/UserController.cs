using Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace UserProject.Controllers
{
    public class UserController : Controller
    {


        private static List<User> Users = new List<User>
        {
            new User { Id = 1, UserName="t1",DateTimeCreateDate=DateTime.Now,IsActive=true,IsDeleted=false,Mobile="09210741437",RegisterDate=DateTime.Now,UserAvatar="sss",UserId=new Guid() },
            new User { Id = 2, UserName="t2",DateTimeCreateDate=DateTime.Now,IsActive=true,IsDeleted=false,Mobile="09210741437",RegisterDate=DateTime.Now,UserAvatar="sss",UserId=new Guid() },
            new User { Id = 3, UserName="t3",DateTimeCreateDate=DateTime.Now,IsActive=true,IsDeleted=false,Mobile="09210741437",RegisterDate=DateTime.Now,UserAvatar="sss",UserId=new Guid() },
            new User { Id = 4, UserName="t4",DateTimeCreateDate=DateTime.Now,IsActive=true,IsDeleted=false,Mobile="09210741437",RegisterDate=DateTime.Now,UserAvatar="sss",UserId=new Guid() },
            new User { Id = 5, UserName="t5",DateTimeCreateDate=DateTime.Now,IsActive=true,IsDeleted=false,Mobile="09210741437",RegisterDate=DateTime.Now,UserAvatar="sss",UserId=new Guid() }


        };



        public IActionResult Index()
            {
                return View();
            }



      
        

        //public JsonResult List()
        //{
        //    return new JsonResult(new
        //    {
        //        Result = "OK",
        //        Records = Users,
        //        TotalRecordCount = Users.Count
        //    })
        //    {
        //        // در صورت نیاز می‌توانید تنظیمات سریال‌سازی را اینجا قرار دهید
        //        // مثلا برای پیکربندی تاریخ یا فیلدهای خاص
        //        SerializerSettings = new JsonSerializerOptions
        //        {
        //            PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // مثال برای تغییر نام‌دهی
        //            WriteIndented = true // برای نمایش ساختار خوانا
        //        }
        //    };
        //}

        [HttpPost]
            public JsonResult Create(User user)
            {
                //user.Id = Users.Count + 1;
                //Users.Add(user);
                return Json(new { Result = "OK", Record = user });
            }

            [HttpPost]
            public JsonResult Update(User user)
            {
               //// var existingUser = Users.FirstOrDefault(u => u.Id == user.Id);
               // if (existingUser == null) return Json(new { Result = "ERROR", Message = "کاربر پیدا نشد" });

               // existingUser.UserName = user.UserName;
             
               return Json(new { Result = "OK" });
            }

            [HttpPost]
            public JsonResult Delete(int Id)
            {
                //var user = Users.FirstOrDefault(u => u.Id == Id);
                //if (user == null) return Json(new { Result = "ERROR", Message = "کاربر پیدا نشد" });

                //Users.Remove(user);
                return Json(new { Result = "OK" });
            }
        }
  
}



