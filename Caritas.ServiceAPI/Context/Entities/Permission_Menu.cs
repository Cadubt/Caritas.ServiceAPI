using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Context.Entities
{
    public class Permission_Menu
    {
        public int Id { get; set; }
        public int PermissionId { get; set; }
        public int MenuId { get; set; }
        public bool Authorization { get; set; }
    }
}
