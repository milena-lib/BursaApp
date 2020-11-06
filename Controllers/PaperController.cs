using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bursa.Models;
using Bursa.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bursa.Controllers
{
    [Route("")]
    [Route("Paper")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class PaperController : ControllerBase
    {
        private ApplicationContext db;
        private readonly PaperService paperService;
        public PaperController(ApplicationContext context, PaperService paperService)
        {
            db = context;
            this.paperService = paperService;
        }

        [HttpGet]
        // [Route("[controller]/[action]")]
        [ActionName("GetPapers")]
        public IActionResult GetPapers()
        {
            string res = paperService.GetPapers();
            //res = "Welcome to the club";
            return Ok(res);
        }
        [HttpGet]
        [Route("[controller]/[action]")]
        [ActionName("GetPaperById")]
        public IActionResult GetUserById(int id)
        {
            string res = "qwerty";//_userService.GetUserById(id);
            return Ok(res);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
