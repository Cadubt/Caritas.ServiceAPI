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
        /// Responsible for create a Sheltered
        /// </summary>
        /// <param name="sheltered"></param>
        /// <returns></returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create(Sheltered sheltered)
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

        /// <summary>
        /// Responsible for Update a Sheltered
        /// </summary>
        /// <param name="sheltered"></param>
        /// <returns></returns>
        [HttpPut("Update")]
        public async Task<IActionResult> Update(Sheltered sheltered)
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

        /// <summary>
        /// Responsible for Update a Sheltered with a Inactive Status
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
        /// Responsible for obtaining a list of all registered shelters, with the required status.
        /// </summary>
        /// <param name="statusId">1 Active|2 Pending|3 Deceased</param>
        /// <returns></returns>
        [HttpGet("ListSheltereds")]
        public async Task<IActionResult> List(int statusId)
        {
            try
            {
                return HttpResponse.Send(true, 200, await _sheltService.List(statusId));
            }
            catch (AppException ex)
            {
                return HttpResponse.Send(false, ex.Code, null, ex.Message);
            }
        }
    }
}