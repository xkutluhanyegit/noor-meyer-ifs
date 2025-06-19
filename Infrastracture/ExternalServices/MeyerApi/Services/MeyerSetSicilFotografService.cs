using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Infrastracture.ExternalServices.MeyerApi.Interfaces;
using Infrastracture.ExternalServices.MeyerApi.Models.Requests;
using Infrastracture.ExternalServices.MeyerApi.Models.Requests.SetSicilFotograf;
using Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository;
using Microsoft.Extensions.Configuration;

namespace Infrastracture.ExternalServices.MeyerApi.Services
{
    public class MeyerSetSicilFotografService : IMeyerSetSicilFotografService
    {
        private readonly IMeyerTokenService _meyerTokenService;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        
        private readonly INoorEmployeeImgRepository _noorEmployeeImgService;

        public MeyerSetSicilFotografService(IMeyerTokenService meyerTokenService,HttpClient httpClient,IConfiguration configuration,INoorEmployeeImgRepository noorEmployeeImgService)
        {
            _meyerTokenService = meyerTokenService;
            _httpClient = httpClient;
            _configuration = configuration;
            _noorEmployeeImgService = noorEmployeeImgService;

        }

        public async Task<string> SetSicilFotografAsync()
        {
            var url_ = "http://192.168.228.71:9092/API/FotografServisi/setSicilFotograf";
            var token_ = _meyerTokenService.GetTokenAsync().Result.successMessage;

            var requestBody = new MeyerSetSicilFotografRequest{
                ConnectAuthentication = new MeyerConnectAuthentication
                {
                    Token = token_
                },
                RequestData = new MeyerFotografRequestData
                {
                    Data = new List<MeyerFotografModel>()
                    
                }
            };

            var collection = _noorEmployeeImgService.GetAllAsync().Result;

            foreach (var item in collection)
            {
                var sicilFotografModel = new MeyerFotografModel{
                    sicilNo = item.EMP_NO,
                    fotoJGPtoBase64 = Convert.ToBase64String(item.DATA)
                };

                requestBody.RequestData.Data.Add(sicilFotografModel);
            }

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = _httpClient.PostAsync(url_, content).Result;

            if (!response.IsSuccessStatusCode)
            {
                var responseText = response.Content.ReadAsStringAsync().Result;
                throw new Exception($"Hata: {response.StatusCode} - {responseText}");
            }

            var responseContent = response.Content.ReadAsStringAsync().Result;
            //var responseData = JsonSerializer.Deserialize<MeyerSetSicilResponse>(responseContent);

            return "1";
        }
    }
}