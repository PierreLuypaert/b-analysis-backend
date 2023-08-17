using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using B_Analysis_BackEnd.Models;
using System.Text.Json;
using B_Analysis_BackEnd.DTOs;
using Newtonsoft.Json;

namespace B_Analysis_BackEnd.Services
{
    public interface IAnalysisService
    {
        Task<Match> GetMatchAnalysis(Match match);
    }

    public class AnalysisService : IAnalysisService
    {
        private readonly HttpClient _httpClient;

        public AnalysisService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Match> GetMatchAnalysis(Match match)
        {
            using (HttpClient client = new HttpClient())
            {
                // Prepare the request payload (if needed)
                var payload = new
                {
                    VideoUrl = match.VideoUrl
                };

                // Serialize the payload to JSON
                string jsonPayload = JsonConvert.SerializeObject(payload);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                try
                {
                    // Send the POST request and get the response
                    HttpResponseMessage response = await client.PostAsync("http://localhost:5000/match-analysis", content);
                    response.EnsureSuccessStatusCode(); // Throws if response status code is not successful

                    // Deserialize the response content to the desired object type (Match)
                    string responseContent = await response.Content.ReadAsStringAsync();
                    MatchAnalysisDTO analysisData = JsonConvert.DeserializeObject<MatchAnalysisDTO>(responseContent);

                    match.BallSpeed = analysisData.BallSpeed;
                    match.BallPosition = analysisData.BallPosition;
                    match.MatchDuration = analysisData.MatchDuration;

                    return match;
                }
                catch (HttpRequestException ex)
                {
                    // Handle network-related errors
                        Console.WriteLine($"HTTP request error: {ex.Message}");
                    throw;
                }
            }
        }

    }
}