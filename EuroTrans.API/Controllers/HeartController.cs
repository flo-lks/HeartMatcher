using EuroTrans.Core;
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
    }
}
