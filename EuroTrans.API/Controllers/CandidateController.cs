using EuroTrans.Core;
using Microsoft.AspNetCore.Mvc;

namespace EuroTrans.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatesController : ControllerBase
    {
        private readonly PatientManager _patientManager;
        private readonly HeartManager _heartManager;
        private readonly CandidateManager _candidateManager;
        private readonly ExtendedMatcher _matcher;

        public CandidatesController(
            PatientManager patientManager,
            HeartManager heartManager,
            CandidateManager candidateManager,
            ExtendedMatcher matcher)
        {
            _patientManager = patientManager;
            _heartManager = heartManager;
            _candidateManager = candidateManager;
            _matcher = matcher;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Candidate>> GetMatches()
        {
            _matcher.Match(_patientManager, _heartManager, _candidateManager);

            var result = _candidateManager.GetAll();

            if (result == null || !result.Any())
            {
                return NotFound("Aktuell konnten keine passenden Paare gematcht werden.");
            }

            return Ok(result);
        }
    }
}
