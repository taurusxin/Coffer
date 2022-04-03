using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Coffer.Interfaces;
using Coffer.Models;

namespace Coffer.Services
{
    public class NewCoffeeService : INewCoffeeService
    {
        private readonly HttpClient _httpClient;

        public NewCoffeeService()
        {
#if DEBUG
            HttpClientHandler insecureHandler = GetInsecureHandler();
            _httpClient = new HttpClient(insecureHandler);
#else
            HttpClient _httpClient = new HttpClient();
#endif
            _httpClient.BaseAddress = new Uri("https://api.icoffer.app/v1/submit/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }
        
        public HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
        
        public async Task<bool> SubmitNewCoffee(NewCoffee newCoffee)
        {
            HttpResponseMessage response = new HttpResponseMessage { StatusCode = System.Net.HttpStatusCode.BadRequest };

            try
            {
                response = await _httpClient.PostAsync("SubmitCoffee",
                    new StringContent(JsonSerializer.Serialize(newCoffee), Encoding.UTF8, "application/json"));
            }
            catch(Exception e)
            {
                Debug.Fail(e.Message);
            }

            return response.IsSuccessStatusCode;
        }
    }
}