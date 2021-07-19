using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarthValidatorBlazor.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValidationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
