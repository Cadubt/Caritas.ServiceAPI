using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Repositories.Interfaces;
using Caritas.ServiceAPI.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services
{
    public class ScheduleSheetService : IScheduleSheetService
    {
        private IConfiguration _config { get; set; }
        private readonly IScheduleSheetRepository _scheduleRepo;

        public ScheduleSheetService(IScheduleSheetRepository scheduleRepo, IConfiguration config)
        {
            _scheduleRepo = scheduleRepo;
            _config = config;
        }
        public async Task<List<ScheduleSheet>> List()
        {
            List<ScheduleSheet> sheltereds = new List<ScheduleSheet>();
            sheltereds = await _scheduleRepo.List();
            return sheltereds;
        }
    }
}
