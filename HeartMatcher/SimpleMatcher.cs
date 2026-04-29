using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public class SimpleMatcher : IMatcher
    {
        public void match(List<Patient> patients, List<Heart> hearts, MatchManager matchManager)
        {
            foreach(Patient candidate in patients)
            {
                foreach(Heart heart in hearts)
                {
                    if (candidate.Bloodtype == heart.Bloodtype) matchManager.Add(new Match(candidate, heart));
                }
            }
        }
    }
}