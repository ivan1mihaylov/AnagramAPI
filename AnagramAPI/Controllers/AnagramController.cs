using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AnagramAPI.Controllers
{
    /// <summary>
    /// Controller for managing anagrams
    /// </summary>
    [ApiController]
    [Route("v1")]
    public class AnagramController : ControllerBase
    {

        private readonly ILogger<AnagramController> _logger;

        public AnagramController(ILogger<AnagramController> logger)
        {
            _logger = logger;
        }

    }
}
