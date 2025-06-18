using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Infrastracture.ExternalServices.MeyerApi.Interfaces;
using Infrastracture.ExternalServices.MeyerApi.Models.Requests;
using Infrastracture.ExternalServices.MeyerApi.Models.Responses;
using Infrastracture.Persistence.Repositories.Dapper.NoorEmployeeRepository;
using Microsoft.Extensions.Configuration;

namespace Infrastracture.ExternalServices.MeyerApi.Services
{
    public class MeyerSetSicilService : IMeyerSetSicilService
    {
        private readonly IMeyerTokenService _meyerTokenService;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        private readonly INoorEmployeeRepository _noorEmployeeService;

        public MeyerSetSicilService(HttpClient httpClient,IConfiguration configuration,IMeyerTokenService meyerTokenService,INoorEmployeeRepository noorEmployeeService)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _meyerTokenService = meyerTokenService;
            _noorEmployeeService = noorEmployeeService;
        }
        public async Task<MeyerSetSicilResponse> SetSicilAsync()
        {
            var url_ = "http://192.168.228.71:9092/API/SicilServisi/setSicil";
            var token_ = _meyerTokenService.GetTokenAsync().Result.successMessage;

            var requestBody = new MeyerSetSicilRequest{
                ConnectAuthentication = new MeyerConnectAuthentication
                {
                    Token = token_
                },
                RequestData = new MeyerSicilRequestData
                {
                    Data = new List<MeyerSicilModel>()
                    
                }
            };

            var collection = _noorEmployeeService.GetAllAsync().Result;
            
            foreach (var item in collection)
            {
                var sicilModel = new MeyerSicilModel
                {
                    Ad = item.FNAME,
                    Soyad = item.LNAME,
                    SicilNo = item.EMP_NO,
                    DogumTarihi = item.DATE_OF_BIRTH,
                    Firma = item.COMPANY_ID,
                    Cinsiyet = item.SEX,
                    Kangrubu = item.BLOOD_TYPE,
                    GirisTarih = DateTime.Now.ToString("yyyy-MM-dd"),
                    CikisTarih = DateTime.Now.ToString("yyyy-MM-dd")
                };
            
            requestBody.RequestData.Data.Add(sicilModel);
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
            var responseData = JsonSerializer.Deserialize<MeyerSetSicilResponse>(responseContent);
            
            var setSicilResponse = JsonSerializer.Deserialize<MeyerSetSicilResponse>(responseContent);

            return await Task.FromResult(setSicilResponse);

        }
    }
}