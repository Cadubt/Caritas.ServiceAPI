using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Interface;
using Caritas.ServiceAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        /// Get Usuarios
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("todos")]
        public ActionResult GetUsers()
        {
            try
            {
                List<UserModel> u = _userService.GetUsers();
                return Ok(u);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }
    }
}