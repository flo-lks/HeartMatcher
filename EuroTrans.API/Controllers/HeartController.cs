using EuroTrans.Core;
using EuroTrans.API.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EuroTrans.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HeartController : ControllerBase
    {
        private readonly HeartManager _heartManager;

        public HeartController(HeartManager heartManager)
        {
            _heartManager = heartManager;
        }

        [HttpGet]
        public ActionResult<List<DonorHeart>> GetHearts()
        {
            var hearts = _heartManager.GetAll();

            if (hearts.Count == 0)
            {
                return NotFound("No recipient patients registered.");
            }

            return Ok(hearts);
        }

        [HttpPost]
        public ActionResult AddHeart([FromBody] HeartCreateDto heartDto)
        {
            var hearts = _heartManager.GetAll();
            int newId = hearts.Count == 0 ? 1 : hearts.Max(h => h.Id) + 1;

            DonorHeart heart = new DonorHeart(
                id: newId,
                bloodType: heartDto.BloodType,
                donorBodyweight: heartDto.DonorBodyweight,
                lat: heartDto.Lat,
                lon: heartDto.Lon,
                isMatched: false
            );

            _heartManager.Add(heart);
            Console.WriteLine($"Added heart: Bloodtype: {heart.BloodType}, Donor Bodyweight: {heart.DonorBodyweight}, Location: ({heart.Lat}, {heart.Lon})");
            _heartManager.WriteHeartsToCSV("DonorHearts.csv");
            return Ok();
        }
    }
}
