using EuroTrans.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;

namespace EuroTrans.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientManager _patientManager;

        public PatientController(PatientManager patientManager)
        {
            _patientManager = patientManager;
        }

        [HttpGet]
        public ActionResult<List<RecipientPatient>> GetPatients()
        {
            var patients = _patientManager.GetAll();

            if (patients.Count == 0)
            {
                return NotFound("No recipient patients registered.");
            }

            return Ok(patients);
        }
    }
}
