using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Helper;
using Caritas.ServiceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caritas.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShelteredController : Controller
    {
        private readonly IShelteredService _sheltService;

        public readonly CaritasContext _context;

        public ShelteredController(CaritasContext context, IShelteredService shelteredService)
        {
            _context = context;
            _sheltService = shelteredService;
        }

        /// <summary>
        /// Responsible to get a list of all registered Sheltereds
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListSheltereds")]
        public async Task<IActionResult> List()
        {
            try
            {
                return HttpResponse.Send(true, 200, await _sheltService.List());
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }
    }
}