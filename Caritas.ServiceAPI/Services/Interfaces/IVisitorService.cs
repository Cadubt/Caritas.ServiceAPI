﻿using Caritas.ServiceAPI.Context.Entities;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Services.Interfaces
{
    public interface IVisitorService
    {
        Task<List<Visitor>> List(DateTime? visitDate);
        Task<bool> Create(Visitor visitor);
    }
}
