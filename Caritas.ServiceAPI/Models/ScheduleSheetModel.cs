using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Caritas.ServiceAPI.Models
{
    public class ScheduleSheetModel
    {
        public int Id { get; set; }
        public string ShelteredName { get; set; }
        public int ShelteredAge { get; set; }
        public string ShelteredPhone { get; set; }
        public string ShelteredAddress { get; set; }
        public string ResponsibleName { get; set; }
        public int KinshipId { get; set; }
        public string ResponsiblePhone { get; set; }
        public string ResponsibleAddress { get; set; }
        public DateTime InterviewDate { get; set; }
        public DateTime ScheduleDate { get; set; }
        public string Observation { get; set; }
        public string ScheduleResponsible { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

    }
}
