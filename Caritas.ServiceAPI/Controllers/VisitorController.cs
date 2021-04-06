using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Helper;
using Caritas.ServiceAPI.Models;
using Caritas.ServiceAPI.Services.Interfaces;
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
    }
}
