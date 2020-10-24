using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Context.Entities
{
    public class Sheltered
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string BloodTyping { get; set; }
        public DateTime EntryDate { get; set; }
        public string PerfilImage { get; set; }
        public DateTime? DeceaseAt { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
