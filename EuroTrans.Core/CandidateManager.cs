using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public class CandidateManager : IManager<Candidate>
    {
        List<Candidate> candidates = new List<Candidate>();

        public List<Candidate> GetAll()
        {
            return candidates;
        }
        public void Add(Candidate match)
        {
            candidates.Add(match);
        }
    }
}