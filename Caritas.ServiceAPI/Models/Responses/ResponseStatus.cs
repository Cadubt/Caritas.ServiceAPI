namespace Caritas.ServiceAPI.Models.Responses
{
    public class ResponseStatus
    {
        public int Code { get; set; }
        public ResponseClass Class { get; set; }
        public string Reason { get; set; }
    }
}
