using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Models
{
    public class ApiKeyScheme
    {
        public string Description { get; set; }
        public string Name { get; set; }
        public string In { get; set; }
        public string Type { get; set; }
    }
}
