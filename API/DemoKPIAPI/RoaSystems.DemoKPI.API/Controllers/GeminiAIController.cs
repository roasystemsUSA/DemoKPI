using Microsoft.AspNetCore.Mvc;
using RoaSystems.DemoKPI.Model.Model.DTO;
using RoaSystems.DemoKPI.Service.Interfaces;

namespace RoaSystems.DemoKPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeminiAIController : ControllerBase
    {
        private readonly IAIService _iAIService;
        public GeminiAIController(IAIService iAIService)
        {
            _iAIService = iAIService;
        }

        /// <summary>
        /// Sends a prompt to Gemini AI and returns the generated response.
        /// </summary>
        [HttpPost("ask")]
        public async Task<ActionResult<ChatResponseDTO>> CreatePrompt([FromBody] ChatRequestDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Prompt))
                return BadRequest("Prompt cannot be empty.");

            try
            {
                // The service handles both the AI call and the persistence logic
                var response = await _iAIService.GenerateResponseAsync(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log the exception (using ILogger would be ideal here)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        /*

        // GET: api/<GeminiAIController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<GeminiAIController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<GeminiAIController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<GeminiAIController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<GeminiAIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        } */
    }
}
