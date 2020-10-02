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

        /// <summary>
        /// Get an specific user by his name
        /// </summary>
        /// <param name="nome"></param>
        /// <returns></returns>
        [HttpGet("GetUser")]
        public ActionResult GetUser(string nome)
        {
            try
            {
                var userFound = _userService.GetUser(nome);
                return Ok(userFound);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        /// <summary>
        /// Responsible to Create an User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("CreateUser")]
        public ActionResult PostUsers([FromBody] UserModel user)
        {
            try
            {
                bool wasCreated = _userService.PostUsers(user);
                if (!wasCreated)
                    return BadRequest($"Error: Nenhum usuario foi enviado para ser cadastrado");

                return Ok("OK");
            }
            catch (Exception)
            {
                return BadRequest($"Error: Nenhum usuario foi enviado para ser cadastrado");
            }
        }

        /// <summary>
        /// Responsible to Update an User by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut("UpdateUser")]
        public ActionResult PutUser(UserModel user)
        {
            try
            {
                var userFound = _userService.PutUser(user);

                if (userFound != null)
                    return Ok(user);

                return BadRequest("A Pesquisa não encontrou nenhum resultado");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }

        /// <summary>
        /// Responsible to Delete an User by Id
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public ActionResult DeleteUsers(int id)
        {
            try
            {
                _userService.DeleteUsers(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex}");
            }
        }



    }
}