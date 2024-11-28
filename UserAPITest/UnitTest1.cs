using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Xunit;
using UserAPITest.TestModels;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace UserAPITest
{
    public class UnitTest1
    {
        private static readonly string baseUrl = "http://localhost:5145";
        private static HttpClient sharedClient = new()
        {
            BaseAddress = new Uri(baseUrl),
        };


        [Fact]
        public async void GenerateTokenTest()
        {
            string jsonResponse = await GetToken();
            ApiResponse resp = JsonSerializer.Deserialize<ApiResponse>(jsonResponse);

            Assert.Equal(HttpStatusCode.OK, resp.statusCode);

        }


        [Fact]
        public async void GetUser()
        {
            string createEndPointURL = baseUrl + "/User/GetAllUser";
            string jsonResponse = await GetToken();
            ApiResponse resp = JsonSerializer.Deserialize<ApiResponse>(jsonResponse);


            HttpClient client = Method_Headers(resp.responseData.token, createEndPointURL);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Uri.EscapeUriString(client.BaseAddress.ToString()));
            HttpResponseMessage tokenResponse = await client.GetAsync(Uri.EscapeUriString(client.BaseAddress.ToString()));
            string data = await tokenResponse.Content.ReadAsStringAsync();

            ApiResponse rolRes = JsonSerializer.Deserialize<ApiResponse>(data);

            Assert.Equal(HttpStatusCode.OK, resp.statusCode);

        }

        [Fact]
        public async void GetRoles()
        {
            string createEndPointURL = baseUrl + "/Role/GetAllRoles";
            string jsonResponse = await GetToken();
            ApiResponse resp = JsonSerializer.Deserialize<ApiResponse>(jsonResponse);


            HttpClient client = Method_Headers(resp.responseData.token, createEndPointURL);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, Uri.EscapeUriString(client.BaseAddress.ToString()));
            HttpResponseMessage tokenResponse = await client.GetAsync(Uri.EscapeUriString(client.BaseAddress.ToString()));
            string data = await tokenResponse.Content.ReadAsStringAsync();

            ApiResponse rolRes = JsonSerializer.Deserialize<ApiResponse>(data);

            Assert.Equal(HttpStatusCode.OK, resp.statusCode);

        }

        public static async Task<string> GetToken()
        {
            using StringContent jsonContent = new(JsonSerializer.Serialize(new User
            {
                UserName = "Abhishek",
                Password = "Bhatnagar"
            }), Encoding.UTF8, "application/json");

            using HttpResponseMessage response = await sharedClient.PostAsync("Login/generatetoken", jsonContent);
            return await response.Content.ReadAsStringAsync();
        }
        private HttpClient Method_Headers(string accessToken, string endpointURL)
        {
            HttpClientHandler handler = new HttpClientHandler() { UseDefaultCredentials = false };
            HttpClient client = new HttpClient(handler);

            try
            {
                client.BaseAddress = new Uri(endpointURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("apikey", "this is my custom Secret key for authentication");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return client;
        }


    }
}