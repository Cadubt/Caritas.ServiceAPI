namespace Caritas.ServiceAPI.Models.Responses
{
    public class ResponseModel
    {
        public bool Success { get; set; }
        public int Code { get; set; }
        public ResponseClass Type { get; set; }

        public dynamic Data { get; set; }
        public dynamic Error { get; set; }
    }
}
