using System;
using System.Net.Http;
using System.Threading.Tasks;
using B_Analysis_BackEnd.Models;
using System.Text.Json; 

namespace B_Analysis_BackEnd.Services
{
    public interface IAnalysisService
    {
        Task<Match> GetMatchAnalysis();
    }

    public class AnalysisService : IAnalysisService
    {
        private readonly HttpClient _httpClient;

        public AnalysisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Match> GetMatchAnalysis()
        {
            try
            {
                // Replace "http://localhost:5000" with the actual URL of your local API.
                HttpResponseMessage response = await _httpClient.GetAsync("http://localhost:5000/match-analysis");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    // Deserialize the JSON response using System.Text.Json.JsonSerializer.
                    Match apiResponse = JsonSerializer.Deserialize<Match>(jsonResponse);
                    return apiResponse;
                }
                else
                {
                    // You can handle different HTTP status codes here if needed.
                    throw new Exception($"API call failed with status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred: {ex.Message}");
            }
        }
    }
}