using EuroTrans.Core;
using EuroTrans.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;

namespace EuroTrans.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientManager _patientManager;
        private readonly HospitalManager _hospitalManager;

        public PatientController(PatientManager patientManager, HospitalManager hospitalManager)
        {
            _patientManager = patientManager;
            _hospitalManager = hospitalManager;
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

        [HttpPost]
        public ActionResult AddPatient([FromBody] PatientCreateDto patientDto)
        {
            Hospital? hospital = _hospitalManager.GetAll()
                .FirstOrDefault(h => h.ID == patientDto.Hospital);

            if (hospital == null)
            {
                return BadRequest("Ungültiges Krankenhaus.");
            }

            var patients = _patientManager.GetAll();
            int newId = patients.Count == 0 ? 1 : patients.Max(p => p.ID) + 1;

            RecipientPatient patient = new RecipientPatient(
                id: newId,
                firstname: patientDto.Firstname,
                lastname: patientDto.Lastname,
                bloodtype: patientDto.Bloodtype,
                bodyweight: patientDto.Bodyweight,
                hospital: hospital
            );

            _patientManager.Add(patient);
            Console.WriteLine($"Added patient: {patient.Firstname} {patient.Lastname}, Bloodtype: {patient.BloodType}, Bodyweight: {patient.Bodyweight}, Hospital: {hospital.Name}");
            _patientManager.WritePatientsToCSV("Patients.csv");
            return Ok();
        }
    }
}
