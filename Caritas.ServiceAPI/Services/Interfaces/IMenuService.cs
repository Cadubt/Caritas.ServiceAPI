﻿using Caritas.ServiceAPI.Context.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services.Interfaces
{
    public interface IMenuService
    {
        Task<List<Menu>> List(int UserID);
    }
}
