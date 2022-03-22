namespace Caritas.ServiceAPI.Context.Entities
{
    public class GeneralSheltInfo
    {
        public int Id { get; set; }
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
