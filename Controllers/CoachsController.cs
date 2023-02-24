using Microsoft.AspNetCore.Mvc;
using rsiot.Contracts.Services;
using rsiot.DataTransferObjects;

namespace rsiot.Controllers
{
    [Route("api/coachs")]
    [ApiController]
    public class CoachsController : ControllerBase
    {
        private readonly ICoachService _coachService;
        private readonly ILogger _logger;
        public CoachsController(ICoachService coachService, ILogger<CoachsController> logger)
        {
            _coachService = coachService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetCoachs()
        {
            var coachs = await _coachService.GetCoachsAsync();
            _logger.LogInformation("got all coachs");

            return Ok(coachs);
        }

        [HttpGet("{id}", Name = "GetCoach")]
        public async Task<IActionResult> GetCoach(Guid id)
        {
            var coach = await _coachService.GetCoachAsync(id);
            _logger.LogInformation($"got coach by id: {id}");

            return Ok(coach);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoach([FromBody] CoachForManipulationDto coachDto)
        {
            var coach = await _coachService.CreateCoachAsync(coachDto);
            _logger.LogInformation("coach was created");

            return CreatedAtRoute("GetCoach", new { id = coach.Id }, coach);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCoach(Guid id, [FromBody] CoachForManipulationDto coachDto)
        {
            await _coachService.UpdateCoachAsync(id, coachDto);
            _logger.LogInformation($"coach was updated, id: {id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoach(Guid id)
        {
            await _coachService.DeleteCoachAsync(id);
            _logger.LogInformation($"coach was deleted, id: {id}");

            return NoContent();
        }
    }
}
