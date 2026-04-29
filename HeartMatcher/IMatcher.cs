using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public interface IMatcher
    {
        void match(List<Patient> candidates, List<Heart> hearts, MatchManager matchManager);
    }
}