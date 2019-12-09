using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnagramAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        [HttpGet]
        public ContentResult Index()
        {
            string content = System.IO.File.ReadAllText("Templates/Index.html");

            return new ContentResult
            {
                ContentType = "text/html",
                Content = content
            };
        }
    }
}