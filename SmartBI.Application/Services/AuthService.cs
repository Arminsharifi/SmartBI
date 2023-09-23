using RestSharp;
using SmartBI.Application.Interfaces;
using SmartBI.Shareds.DataTransferObjects;

namespace SmartBI.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly RestClientOptions _options;


        public AuthService()
        {
            _options = new RestClientOptions("https://localhost:7142/api");
        }

        public async Task<JwtDto> Authenticate(string UserName, string Password)
        {
            RestClient client = new RestClient(_options);
            var request = new RestRequest("/Auth/Authenticate", Method.Post);
            var dataToSend = new
            {
                userName = UserName,
                password = Password

            };
            request.AddJsonBody(dataToSend);
            var JwtDto = await client.PostAsync(request);

            return new JwtDto("a", 2);
        }
    }
}