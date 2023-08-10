using B_Analysis_BackEnd.Models;
using System.Collections.Generic;

namespace B_Analysis_BackEnd.Repository
{
    public interface IPlayerRepository
    {
        void AddPlayer(Player player);

        List<Player> GetPlayers();
    }

    public class PlayerRepository : IPlayerRepository
    {
        private readonly BAnalysisContext _context;

        public PlayerRepository(BAnalysisContext context)
        {
            _context = context;
        }

        public List<Player> GetPlayers()
        {
            return _context.Players.ToList();
        }
        
        public void AddPlayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
        }

    }
}