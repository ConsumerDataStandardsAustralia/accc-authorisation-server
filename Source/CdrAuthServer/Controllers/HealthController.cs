using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CdrAuthServer.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CdrAuthServer.Controllers
{
    [Route("health")]
    public class HealthController : Controller
    {
        [HttpGet("status")]
        public IActionResult Index()
        {
            return Json(new Health() { Status = "OK" });
        }
    }
}

