using Newtonsoft.Json;
using RestSharp;
using SmartBI.Application.Interfaces;
using SmartBI.Shareds.DataTransferObjects;
using System.Net;

namespace SmartBI.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly RestClientOptions _options;

        public AuthService()
        {
            _options = new RestClientOptions("https://localhost:7142/api");
        }

        public async Task<JwtDto?> AuthenticateAsync(string UserName, string Password)
        {
            RestClient client = new(_options);
            RestRequest request = new("/Auth/Authenticate", Method.Post);
            var dataToSend = new
            {
                userName = UserName,
                password = Password
            };
            request.AddJsonBody(dataToSend);
            RestResponse? JwtResponse = await client.ExecutePostAsync(request);
            if (JwtResponse is not null && JwtResponse.StatusCode == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<JwtDto>(JwtResponse.Content);
            else
                return null;
        }
    }
}