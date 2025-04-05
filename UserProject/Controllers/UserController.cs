using Domain.Models.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace UserProject.Controllers
{
    public class UserController : Controller
    {



        public IActionResult Index()
            {
                return View();
            }


       

    }
  
}



