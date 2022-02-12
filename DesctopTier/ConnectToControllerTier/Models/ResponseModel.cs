using System.Net;

namespace ConnectToControllerTier.Models
{
    public class ResponseModel
    {
        public ResponseModel(HttpStatusCode statusCode, string description)
        {
            DescriptionResponse = description;
            CodeResponse = statusCode;
        }

        public HttpStatusCode CodeResponse { get; set; }
        public string DescriptionResponse { get; set; }
    }
}
