using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Helper;
using Caritas.ServiceAPI.Models;
using Caritas.ServiceAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Caritas.ServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ScheduleSheetController : ControllerBase
    {
        private readonly IScheduleSheetService _scheduleSheetService;

        public readonly CaritasContext _context;

        public ScheduleSheetController(CaritasContext context, IScheduleSheetService scheduleSheetService)
        {
            _context = context;
            _scheduleSheetService = scheduleSheetService;
        }

        /// <summary>
        /// Responsible for create a Sheltered
        /// </summary>
        /// <param name="sheltered"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(ScheduleSheet sheltered)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return HttpResponse.Send(true, 201, _scheduleSheetService.Create(sheltered), null);
                }

                return HttpResponse.Send(true, 400, ModelState, null);
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }

        /// <summary>
        /// Responsible to return a list of Schadules
        /// </summary>
        /// <param name="statusId"></param>
        /// <returns></returns>
        [HttpGet("ListScheduleSheet")]
        public async Task<IActionResult> List()
        {
            try
            {
                return HttpResponse.Send(true, 200, await _scheduleSheetService.List());
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }
    }
}