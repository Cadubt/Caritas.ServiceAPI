using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Helper;
using Caritas.ServiceAPI.Models;
using Caritas.ServiceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Services;

namespace Caritas.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public readonly CaritasContext _context;

        public UserController(CaritasContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        /// <summary>
        /// Responsible to get a list of all registered Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListUsers")]
        //[Authorize]
        public async Task<IActionResult> List()
        {
            try
            {
                return HttpResponse.Send(true, 200, await _userService.List());
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }

        /// <summary>
        /// Responsible for Update a User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return HttpResponse.Send(true, 200, await _userService.Update(user), null);
                }

                return HttpResponse.Send(true, 400, ModelState, null);
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]LoginModel loginModel)
        {
            User user = await _userService.Read(loginModel);


            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenService.GenerateToken(user);

            return new 
            { 
                userEmail = user.Email,
                token = token
            };

        }
    }
}