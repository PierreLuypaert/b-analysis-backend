using B_Analysis_BackEnd.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace B_Analysis_BackEnd.Repository
{
    public interface IMatchRepository
    {
        void AddMatch(Match match);
        List<Match> GetMatches();
    }

    public class MatchRepository : IMatchRepository
    {
        private readonly BAnalysisContext _context;

        public MatchRepository(BAnalysisContext context)
        {
            _context = context;
        }
        
        public List<Match> GetMatches()
        {
            return _context.Matches
                .Include(m => m.BlueDefender)
                .Include(m => m.BlueAttacker)
                .Include(m => m.RedDefender)
                .Include(m => m.RedAttacker)
                .OrderByDescending(m => m.Date)
                .ToList();
        }

        
        public void AddMatch(Match match)
        {
            _context.Matches.Add(match);
            _context.SaveChanges();
        }

    }
}