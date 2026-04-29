using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class MatchManager : IManager<Match>
    {
        List<Match> matches = new List<Match>();

        public List<Match> GetAll()
        {
            return matches;
        }
        public void Add(Match match)
        {
            matches.Add(match);
        }
    }
}