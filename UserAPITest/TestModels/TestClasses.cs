using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserAPITest.TestModels
{
    public class User
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    public class ApiResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public string? ResponseMessage { get; set; }
        public Token responseData { get; set; }
    }
    public class Token
    {
        public string token { get; set; }
    }
}
