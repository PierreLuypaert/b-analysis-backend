using B_Analysis_BackEnd.Models;
using B_Analysis_BackEnd.Repository;

namespace B_Analysis_BackEnd.Services
{
    public interface IPlayerService
    {
        void AddPlayer(Player player);
        List<Player> GetPlayers();
    }

    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }
        
        public List<Player> GetPlayers()
        {
            return _playerRepository.GetPlayers();
        }

        public void AddPlayer(Player player)
        {
            _playerRepository.AddPlayer(player);
        }

    }
}