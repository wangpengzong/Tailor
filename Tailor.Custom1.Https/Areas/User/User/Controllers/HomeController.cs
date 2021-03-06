﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using Default.Models;
using Microsoft.AspNetCore.Http;

namespace Default.Areas.User.Controllers
{
    [Area("User")]
    [ApiVersion("1.0")]
    [Route("[area]/[controller]/[action]")]
    [ApiController]
    public class HomeController : Controller, IBaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILoginUserService _userService;

        public HomeController(ILogger<HomeController> logger, ILoginUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public virtual IActionResult Index()
        {
            ViewBag.Form = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace;
            
            return View(_userService.GetLoginUser());
        }

        public JsonResult GetJson()
        {
            return Json(_userService.GetLoginUser());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
