using System.Net;
using System.Net.Http;
namespace DataAccessLayer.Models
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? ResponseMessage { get; set; }
        public object ResponseData { get; set; }
    }


}
