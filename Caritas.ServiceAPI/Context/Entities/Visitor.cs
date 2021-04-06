using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Context.Entities
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int KinshipId { get; set; }
        public string Adress { get; set; }
        public string RG { get; set; }
        public int ShelteredId { get; set; }
        public DateTime VisitDate { get; set; }
    }
}
