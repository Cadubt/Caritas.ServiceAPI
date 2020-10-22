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
        
        public async Task<bool> Create(ShelteredModel sheltered)
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

        public async Task<bool> Update(ShelteredModel sheltered)
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
            ShelteredModel sheltered = await _sheltRepo.FindShelteredAsync(Id);

            _sheltRepo.SoftDelete<ShelteredModel>(sheltered);

            return await _sheltRepo.Commit() > 0;
        }

        public Task<ShelteredModel> Find(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ShelteredModel>> List(bool aliveOnly, bool activeOnly)
        {
            List<ShelteredModel> s = new List<ShelteredModel>();
            s = await _sheltRepo.List();
            return s;
        }

    }
}
