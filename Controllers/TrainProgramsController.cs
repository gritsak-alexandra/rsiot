using rsiot.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;
using rsiot.Contracts.Services;

namespace webapi.Controllers
{
    [Route("api/coachs/{coachId}/train-programs")]
    [ApiController]
    public class TrainProgramsController : ControllerBase
    {
        private readonly ITrainProgramService _trainProgramService;
        private readonly ILogger _logger;
        public TrainProgramsController(ITrainProgramService trainProgramService, ILogger<TrainProgramsController> logger)
        {
            _trainProgramService = trainProgramService;
            _logger = logger;
        }

        [HttpGet("/api/train-programs")]
        public async Task<IActionResult> GetTrainPrograms()
        {
            var trainPrograms = await _trainProgramService.GetTrainProgramsAsync();
            _logger.LogInformation("got all trainPrograms");

            return Ok(trainPrograms);
        }

        [HttpGet("{id}", Name = "GetTrainProgram")]
        public async Task<IActionResult> GetTrainProgram(Guid coachId, Guid id)
        {
            var trainProgram = await _trainProgramService.GetTrainProgramAsync(coachId, id);
            _logger.LogInformation($"got trainProgram by id: {id}");

            return Ok(trainProgram);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrainProgram(Guid coachId, [FromBody] TrainProgramForManipulationDto trainProgramDto)
        {
            var trainProgram = await _trainProgramService.CreateTrainProgramAsync(coachId, trainProgramDto);
            _logger.LogInformation("trainProgram was created");

            return CreatedAtRoute("GetTrainProgram", new { coachId = trainProgram.CoachId, id = trainProgram.Id }, trainProgram);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrainProgram(Guid coachId, Guid id, [FromBody] TrainProgramForManipulationDto trainProgramDto)
        {
            await _trainProgramService.UpdateTrainProgramAsync(coachId, id, trainProgramDto);
            _logger.LogInformation($"trainProgram was updated, id: {id}");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrainProgram(Guid coachId, Guid id)
        {
            await _trainProgramService.DeleteTrainProgramAsync(coachId, id);
            _logger.LogInformation($"trainProgram was deleted, id: {id}");

            return NoContent();
        }
    }
}
