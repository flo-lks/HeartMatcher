using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeartMatcher
{
    public interface IMatcher
    {
        void Match(PatientManager patientManager, HeartManager heartManager, MatchManager matchManager);
    }
}