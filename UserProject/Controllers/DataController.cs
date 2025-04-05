using Application.Interfaces;
using Domain.Models.User;
using Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace UserProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private IUserService _userService;
        public DataController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetPeople")]
        public IActionResult GetPeople(int jtStartIndex = 0, int jtPageSize = 0, string jtSorting = null)
        {


            // صفحه‌بندی
            UserListViewModel model = _userService.GetUsers(jtStartIndex, jtPageSize);
            var pagedPeople = model.Users;

            // مرتب‌سازی
            if (!string.IsNullOrEmpty(jtSorting))
            {
                var sortParams = jtSorting.Split(' ');
                var property = sortParams[0]; // نام فیلد (مثلاً "Name")
                var direction = sortParams.Length > 1 && sortParams[1].ToLower() == "desc" ? "descending" : "ascending";

                // استفاده از Dynamic LINQ برای مرتب‌سازی
                var orderByExpression = $"{property} {direction}";
                pagedPeople = pagedPeople.AsQueryable().OrderBy(orderByExpression).ToList();
            }

            return Ok(new { Result = "OK", Records = pagedPeople, TotalRecordCount = model.count });
        }




        [HttpGet("GetPerson/{id}")]
        public ActionResult<UserDetail> GetPerson(int id)
        {
            // جستجو برای شخص با استفاده از شناسه
            var person = _userService.GetUserDetail(id);

            // بررسی اینکه آیا شخص پیدا شد یا خیر
            if (person == null)
            {
                return NotFound(new { Message = "کاربر پیدا نشد!" });
            }

            // اگر فرد پیدا شد، جزئیات را برمی‌گردانیم
            return Ok(person);
        }


        [HttpGet("GetUpdate/{id}")]
        public ActionResult<PersonViewModel> GetUpdate(int id)
        {
            // جستجو برای شخص با استفاده از شناسه
            var person = _userService.GetPerson(id);

            // بررسی اینکه آیا شخص پیدا شد یا خیر
            if (person == null)
            {
                return NotFound(new { Message = "کاربر پیدا نشد!" });
            }
            person.Id = id;
            // اگر فرد پیدا شد، جزئیات را برمی‌گردانیم
            return Ok(person);
        }



        //add or update
        [HttpPost("AddPerson")]
        public async Task<IActionResult> AddPerson([FromBody] PersonViewModel newPerson)
        {
            if (await _userService.AddUserORUpdate(newPerson) == ServicesStatus.sucsuccess)
            {
                return Ok(new { Result = "OK", Record = newPerson });

            }

            //// برای تست، فقط یک شناسه تصادفی به کاربر اختصاص می‌دهیم
            //newPerson.Id = new Random().Next(100, 1000);

            return BadRequest("عملیات ناموفق");
        }




        [HttpDelete("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _userService.DeleteUser(id); // متد DeletePerson را در سرویس خود پیاده‌سازی کنید.
                return Ok(new { Message = "کاربر با موفقیت حذف شد!" });
            } catch
            {
                return NotFound(new { Message = "کاربر پیدا نشد!" });
            }
        }












    }





}


