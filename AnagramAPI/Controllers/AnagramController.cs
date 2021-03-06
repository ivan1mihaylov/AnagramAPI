﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnagramAPI.Contracts;
using AutoMapper;
using Domain.DTOs;
using Domain.Extensions;
using Entity;
using Entity.Contracts;
using Entity.Entities.Anagram;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AnagramAPI.Controllers
{
    /// <summary>
    /// Controller for managing anagrams
    /// </summary>
    [Route("anagram")]
    [ApiController]
    public class AnagramController : ControllerBase
    {
        private readonly ILogger<AnagramController> _logger;
        private readonly IAnagramContext _context;

        public AnagramController(ILogger<AnagramController> logger, IAnagramContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// Save the provided base64 encoded string to the database
        /// </summary>
        /// <param name="encodedString">base64 encoded string</param>
        /// <returns>Id of the saved item</returns>
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> SaveNewAnagram([FromBody]string encodedString)
        {
            var result = await _context.SaveNewWord(encodedString);

            return result.HasError 
                ? BadRequest(result.ErrorMessage) 
                : (IActionResult)Ok((result as BaseDTO).Id);
        }

        /// <summary>
        /// Check if two words are anagrams
        /// </summary>
        /// <param name="ID1">ID of the first word</param>
        /// <param name="ID2">ID of the second word</param>
        /// <returns>URL to the another endpoint for result check</returns>
        [Authorize]
        [HttpGet]
        [Route("{ID1:int}/{ID2:int}")]
        public async Task<IActionResult> CheckAnagram(int ID1, int ID2)
        {
            var address = $"{Request.Scheme}://{Request.Host}";
            var result = await _context.CheckAnagram(ID1, ID2, address);

            return result.HasError 
                ? BadRequest(result.ErrorMessage) 
                : (IActionResult)Ok((result as ResultDTO).Url);
        }

        /// <summary>
        /// Get the result of the previous check if two words are anagrams
        /// </summary>
        /// <param name="id">ID of the result</param>
        /// <returns>JSON with result information</returns>
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> CheckAnagram(int id)
        {
            var result = await _context.GetCheckResult(id);

            return result.HasError
                ? BadRequest(result.ErrorMessage)
                : (IActionResult)Ok((result as CheckResultDTO));
        }


    }
}
