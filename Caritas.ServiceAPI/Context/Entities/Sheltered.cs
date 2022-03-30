using Caritas.ServiceAPI.Context.Entities.Enums;
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
        public char Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string? BloodTyping { get; set; }
        public string Nationality { get; set; }
        public string MaritalStatus { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public bool HasIncome { get; set; }
        public string? SourceOfIncome { get; set; }
        public string ResidesIn { get; set; }
        public bool AcceptsToBeWelcomed { get; set; }
        public bool BeenAnotherInstitution { get; set; }
        public string AnotherInstitutionName { get; set; }
        public string HowFindOutShelter { get; set; }
        public DateTime EntryDate { get; set; }
        public string PerfilImage { get; set; }
        public DateTime? DeceaseAt { get; set; }
        public int StatusId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string ApprovalStatus { get; set; }
        public decimal IncomeAmount { get; set; }

        //Responsible Info
        public string ResponsibleName { get; set; }
        public string ResponsibleKinship { get; set; }
        public string ResponsiblePhone { get; set; }
        public string ResponsibleAddress { get; set; }
        public string ResponsibleNeighborhood { get; set; }

        //General Info
        public string HealthProblem { get; set; }
        public string MedicalInsurance { get; set; }
        public bool HasMedicalTreatment { get; set; }
        public string WhichHospital { get; set; }
        public string Disability { get; set; }
        public string HowMoves { get; set; }
        public bool Smoker { get; set; }
        public bool Drinker { get; set; }
        public bool FeedsItself { get; set; }
        public string ControlledMedicine { get; set; }
        public bool GoOutAline { get; set; }
        public string AnyOccurrence { get; set; }

    }
}
