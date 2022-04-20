using Caritas.ServiceAPI.Context.Entities;
using Caritas.ServiceAPI.Helper;
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
        
        public async Task<bool> Create(Sheltered sheltered)
        {
            try
            {
                await _sheltRepo.Add(sheltered);
                int changed = await _sheltRepo.Commit();

                if (changed > 0)
                    return true;

                return false;
            }
            catch (AppException ex)
            {
                throw new AppException(ex.Message, ex.Code);
            }
        }

        public async Task<bool> Update(Sheltered sheltered)
        {
            try
            {
                _sheltRepo.Update(sheltered);
                int changed = await _sheltRepo.Commit();

                if (changed > 0)
                    return true;

                return false;
            }
            catch (AppException ex)
            {
                throw new AppException(ex.Message, ex.Code);
            }
        }

        public async Task<bool> Delete(int Id)
        {
            Sheltered sheltered = await _sheltRepo.FindShelteredAsync(Id);

            _sheltRepo.SoftDelete<Sheltered>(sheltered);

            return await _sheltRepo.Commit() > 0;
        }

        public async Task<Sheltered> Find(int Id)
        {
            Sheltered sheltered = new Sheltered();
            sheltered = await _sheltRepo.FindShelteredAsync(Id);
            return sheltered;
        }

        public async Task<List<Sheltered>> List(int status, SheltApprovalStatusModel approvalStatus)
        {
            List<Sheltered> sheltereds = new List<Sheltered>();
            sheltereds = await _sheltRepo.List(status, approvalStatus);
            return sheltereds;
        }

    }
}
