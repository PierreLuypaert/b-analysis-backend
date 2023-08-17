using B_Analysis_BackEnd.Models;
using B_Analysis_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace B_Analysis_BackEnd.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")] 
    public class MatchController : ControllerBase
    {
        private readonly IMatchService _matchService;
        private readonly IAnalysisService _analysisService;

        public MatchController(IMatchService matchService, IAnalysisService analysisService)
        {
            _matchService = matchService;
            _analysisService = analysisService;
        }
        
        [HttpGet("all")]
        public IActionResult GetMatches()
        {
            try
            {
                List<Match> matches = _matchService.GetMatches();
                return Ok(matches);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching matches: {ex.Message}");
            }
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateMatch([FromBody] Match match)
        {
            try
            {
                match.Date = DateTime.UtcNow;
                match = await _analysisService.GetMatchAnalysis(match);
                _matchService.AddMatch(match);
                return Ok("Match created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating matches: {ex.Message}");
            }
        }
    }
}