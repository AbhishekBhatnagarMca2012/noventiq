using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xunit;
using UserAPITest.TestModels;

namespace UserAPITest
{
    public class UnitTest1
    {
        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri("http://localhost:5145"),
        };


        [Fact]
        public async void GenerateTokenTest()
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(new User
            {
                UserName = "Abhishek",
                Password = "Bhatnagar"
            }), Encoding.UTF8, "application/json");   // Arrange

            using HttpResponseMessage response = await sharedClient.PostAsync("Login/generatetoken", jsonContent);   // action
            var jsonResponse = await response.Content.ReadAsStringAsync();
            ApiResponse resp = JsonSerializer.Deserialize<ApiResponse>(jsonResponse);

            Assert.Equal(HttpStatusCode.OK, resp.statusCode);   // assert

        }


        
    }
}