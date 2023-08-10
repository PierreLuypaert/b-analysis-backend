using B_Analysis_BackEnd.Models;
using B_Analysis_BackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace B_Analysis_BackEnd.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")] 
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService _playerService;

        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }
        
        
        [HttpGet("all")]
        public IActionResult GetPlayers()
        {
            try
            {
                List<Player> players = _playerService.GetPlayers();
                return Ok(players);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error fetching players: {ex.Message}");
            }
        }
        
        [HttpPost("create")]
        public IActionResult CreatePlayer([FromBody] Player player)
        {
            try
            {
                _playerService.AddPlayer(player);
                return Ok("Player created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error creating player: {ex.Message}");
            }
        }
    }
}
