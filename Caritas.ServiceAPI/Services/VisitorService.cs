using Caritas.ServiceAPI.Context;
using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Models;
using Caritas.ServiceAPI.Repositories.Interfaces;
using Caritas.ServiceAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services
{
    public class VisitorService : IVisitorService
    {
        private IConfiguration _config { get; set; }
        private readonly IVisitorRepository _visitorRepo;

        public VisitorService(IVisitorRepository visitorRepo, IConfiguration config)
        {
            _config = config;
            _visitorRepo = visitorRepo;
        }

        public async Task<List<Visitor>> List(DateTime? visitDate)
        {
            List<Visitor> u = new List<Visitor>();
            string FilteredDate = visitDate?.ToString("MM/dd/yyyy");
            if (visitDate != null)                
                u = await _visitorRepo.ListByDate(FilteredDate);
            else
                u = await _visitorRepo.List();            
            return u;
        }
    }
}
