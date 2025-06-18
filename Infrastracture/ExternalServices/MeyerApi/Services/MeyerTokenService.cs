using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Infrastracture.ExternalServices.MeyerApi.Interfaces;
using Infrastracture.ExternalServices.MeyerApi.Models.Responses;
using Microsoft.Extensions.Configuration;

namespace Infrastracture.ExternalServices.MeyerApi.Services
{
    public class MeyerTokenService : IMeyerTokenService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        public MeyerTokenService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }
        public Task<MeyerTokenResponses> GetTokenAsync()
        {
            var baseUrl = _configuration.GetSection("MeyerApi:BaseUrl").Value;
            var pin_ = _configuration.GetSection("MeyerApi:Pin").Value;
            var password_ = _configuration.GetSection("MeyerApi:Password").Value;
            var username_ = _configuration.GetSection("MeyerApi:Username").Value;
            
            var requestBody = new
            {
                pin = pin_,
                password = password_,
                username = username_
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(baseUrl, content).Result;
            
            if (!response.IsSuccessStatusCode)
            {
                var responseText = response.Content.ReadAsStringAsync().Result;
                throw new Exception($"Hata: {response.StatusCode} - {responseText}");
            }

            var responseContent = response.Content.ReadAsStringAsync().Result;
            var tokenResponse = JsonSerializer.Deserialize<MeyerTokenResponses>(responseContent);

            
            return Task.FromResult(tokenResponse);
        }
    }
}