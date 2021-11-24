using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Helper;
using Caritas.ServiceAPI.Models;
using Caritas.ServiceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Caritas.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : Controller
    {
        private readonly IVisitorService _vistorService;
        public readonly CaritasContext _context;

        public VisitorController(CaritasContext context, IVisitorService vistorService)
        {
            _context = context;
            _vistorService = vistorService;
        }

        /// <summary>
        /// Responsible to get a list of all registered Visitors
        /// </summary>
        /// <param name="visitDate">If not used, method will return all results</param>
        /// <returns></returns>
        [HttpGet("ListVisitors")]
        [Authorize]
        public async Task<IActionResult> List(DateTime? visitDate)
        {
            try
            {
                return HttpResponse.Send(true, 200, await _vistorService.List(visitDate));
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }

        [HttpPost("CreateVisitors")]
        public async Task<IActionResult> Create(Visitor visitor)
        {
            try
            {
                return HttpResponse.Send(true, 200, await _vistorService.Create(visitor));
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }
    }
}
