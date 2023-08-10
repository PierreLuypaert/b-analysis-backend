using B_Analysis_BackEnd.Models;
using B_Analysis_BackEnd.Repository;

namespace B_Analysis_BackEnd.Services
{
    public interface IMatchService
    {
        void AddMatch(Match match);
        List<Match> GetMatches();
    }

    public class MatchService : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }
        
        public List<Match> GetMatches()
        {
            return _matchRepository.GetMatches();
        }
        public void AddMatch(Match match)
        {
            _matchRepository.AddMatch(match);
        }

    }
}