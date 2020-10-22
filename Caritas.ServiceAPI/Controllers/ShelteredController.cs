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
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ShelteredController : Controller
    {
        private readonly IShelteredService _sheltService;

        public readonly CaritasContext _context;

        public ShelteredController(CaritasContext context, IShelteredService shelteredService)
        {
            _context = context;
            _sheltService = shelteredService;
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create(ShelteredModel sheltered)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return HttpResponse.Send(true, 201, await _sheltService.Create(sheltered), null);
                }

                return HttpResponse.Send(true, 400, ModelState, null);
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(ShelteredModel sheltered)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return HttpResponse.Send(true, 200, await _sheltService.Update(sheltered), null);
                }

                return HttpResponse.Send(true, 400, ModelState, null);
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return HttpResponse.Send(true, 200, await _sheltService.Delete(id), null);

            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Detail(int id)
        {
            try
            {
                return HttpResponse.Send(true, 200, await _sheltService.Find(id), null);

            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }

        /// <summary>
        /// Responsible to get a list of all registered Sheltereds
        /// </summary>
        /// <returns></returns>
        [HttpGet("ListSheltereds")]
        public async Task<IActionResult> List(bool aliveOnly, bool activeOnly)
        {
            try
            {
                return HttpResponse.Send(true, 200, await _sheltService.List(aliveOnly, activeOnly));
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }
    }
}