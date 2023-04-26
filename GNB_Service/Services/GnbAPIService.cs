using GNB_Data.Response;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace GNB_Service.Services
{
    public class GnbAPIService : IGnbAPI
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration config;
        public GnbAPIService(HttpClient httpClient, IConfiguration config)
        {
            this.httpClient = httpClient;
            this.config = config;
        }
        public async ValueTask<RateResponseDTO> GetAPIRates()
        {
            return await GetContent<RateResponseDTO>(GetFullPath("rates.json"));
        }

        public async ValueTask<TransactionResponseDTO> GetTransactions()
        {            
            return await GetContent<TransactionResponseDTO>(GetFullPath("transactions.json"));
        }
        private string GetFullPath(string finalPhrase)
        {
            return config.GetSection("GnbAPI")["ApiUrl"] + finalPhrase;
        }
        private async Task<TResult>GetContent<TResult>(string path)
        {
            var response = await httpClient.GetAsync(path);
            if (!response.IsSuccessStatusCode) throw new Exception(response.StatusCode.ToString());

            var result = await response.Content.ReadFromJsonAsync<TResult>();
            return result;
        }
    }
}
