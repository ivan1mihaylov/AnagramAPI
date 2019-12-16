using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Domain.DTOs;
using IdentityModel;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AnagramAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("getToken")]
        public async Task<IActionResult> CheckAnagram([FromBody] UserLogin userLogin)
        {
            using (var httpClient = new HttpClient())
            {
                var disco = await httpClient.GetDiscoveryDocumentAsync(_configuration["IdentityServerAddress"]);
                var tokenClient = new TokenClient(httpClient, new TokenClientOptions()
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "AnagramAPI",
                    ClientSecret = "secret"
                });

                var tokenResponse = await tokenClient.RequestPasswordTokenAsync(userLogin.Username, userLogin.Password);

                return Ok(tokenResponse.AccessToken);
            }
        }
    }
}