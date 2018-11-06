using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServiceA.Classs;

namespace ServiceA.Controllers
{

    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserService userService;

        public UserController(UserService _service)
        {
            userService = _service;
        }


        [Route("login")]
        public string Login(string user, string pwd)
        {
            return userService.Login(user, pwd);
        }

        [Route("logout")]
        public string Logout(string token)
        {
            userService.Logout(token);
            return "ok";
        }

        [Route("verify")]
        public ActionResult Verify(string token)
        {
            User user = userService.GetUserByToken(token);
            if (user == null)
            {
                user = new User() { };
            }
            return Json(user);
        }



    }
}