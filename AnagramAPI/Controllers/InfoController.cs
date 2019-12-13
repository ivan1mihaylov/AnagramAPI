using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnagramAPI.Controllers
{
    /// <summary>
    /// Soleily for returning landing page on API start
    /// </summary>
    [Route("")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        /// <summary>
        /// Return the static file Templates/Index.html as landing page.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
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