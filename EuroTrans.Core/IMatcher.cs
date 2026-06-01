using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EuroTrans.Core
{
    public interface IMatcher
    {
        void Match(PatientManager patientManager, HeartManager heartManager, CandidateManager matchManager, HospitalManager hospitalManager);
    }
}