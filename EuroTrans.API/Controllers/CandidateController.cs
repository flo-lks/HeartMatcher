using EuroTrans.Core;
using Microsoft.AspNetCore.Mvc;

namespace EuroTrans.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly HospitalManager _hosptialManager;
        private readonly PatientManager _patientManager;
        private readonly HeartManager _heartManager;
        private readonly CandidateManager _candidateManager;
        private readonly ExtendedMatcher _matcher;

        public CandidateController(
            HospitalManager hospitalManager,
            PatientManager patientManager,
            HeartManager heartManager,
            CandidateManager candidateManager,
            ExtendedMatcher matcher)
        {
            _hosptialManager = hospitalManager;
            _patientManager = patientManager;
            _heartManager = heartManager;
            _candidateManager = candidateManager;
            _matcher = matcher;
        }

        [HttpGet]
        public ActionResult<List<Candidate>> GetCandidates()
        {
            _matcher.Match(_patientManager, _heartManager, _candidateManager);

            var candidates = _candidateManager.GetAll();

            if (candidates.Count == 0)
            {
                return NotFound("no candidates found");
            }

            return Ok(candidates);
        }
    }
}
