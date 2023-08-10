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

        public MatchController(IMatchService matchService)
        {
            _matchService = matchService;
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
        public IActionResult CreatePlayer([FromBody] Match match)
        {
            try
            {
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