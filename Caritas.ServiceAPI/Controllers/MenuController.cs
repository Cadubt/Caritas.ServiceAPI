using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpResponse = Caritas.ServiceAPI.Helper.HttpResponse;
using Microsoft.AspNetCore.Authorization;

namespace Caritas.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public readonly CaritasContext _context;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// Responsible for obtaining a list of all menu items according his permission.
        /// </summary>
        /// <param name="UserRole"></param>
        /// <returns></returns>
        [HttpGet("ListMenu")]
        [Authorize]
        public async Task<IActionResult> List(int UserRole)
        {
            try
            {
                return HttpResponse.Send(true, 200, await _menuService.List(UserRole));                
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }
    }
}
