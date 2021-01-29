using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Context.Entities
{
    public class Permission
    {
        public int Id { get; set; }

        public bool PermissionStatus { get; set; }

        public string PermissionName { get; set; }
    }
}
