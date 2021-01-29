using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Context.Entities
{
    public class Responsible
    {
        public int Id { get; set; }
        public string ResponsibleName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string KinshipId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
