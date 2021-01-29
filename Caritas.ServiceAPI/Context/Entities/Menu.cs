using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Context.Entities
{
    public class Menu
    {
        public int Id { get; set; }

        public string MenuTittle { get; set; }

        public string PageName { get; set; }

        public string MenuIcon { get; set; }
    }
}
