using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Context.Entities
{
    public class ShelteredStatus
    {
        public int Id { get; set; }
        [Required]
        public string StatusName { get; set; }
    }
}
