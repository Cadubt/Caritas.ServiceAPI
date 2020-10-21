using Caritas.ServiceAPI.Models;
using Caritas.ServiceAPI.Repositories.Interfaces;
using Caritas.ServiceAPI.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services
{
    public class ShelteredService : IShelteredService
    {
        private IConfiguration _config { get; set; }
        private readonly IShelteredRepository _sheltRepo;

        public ShelteredService(IShelteredRepository sheltRepo, IConfiguration config)
        {
            _sheltRepo = sheltRepo;
            _config = config;
        }

        public async Task<List<ShelteredModel>> List()
        {
            List<ShelteredModel> s = new List<ShelteredModel>();
            s = await _sheltRepo.List();
            return s;
        }
    }
}
