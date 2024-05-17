using Capital.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace Capital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ICosmosDbService _cosmosDbService;

        public ApplicationController(ICosmosDbService cosmosDbService)
        {
            _cosmosDbService = cosmosDbService;
        }

        public ApplicationController()
        {
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ApplicationFormData formData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Store the form data in Cosmos DB
                await _cosmosDbService.AddApplicationDataAsync(formData);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        // GET api/application/questions
        [HttpGet("questions")]
        public IActionResult GetQuestions()
        {
            // Logic to retrieve and render questions based on question type
            // Example logic:
            var questions = new[]
            {
                new { Question = "What is your favorite color?", Type = "Dropdown" },
                new { Question = "Do you have any pets?", Type = "YesNo" },
                // Add more questions as needed
            };

            return Ok(questions);
        }

        
        /*
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestions(string id, [FromBody] Program program)
        {
            // Validate input data
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Update in Cosmos DB
            var updatedProgram = await _cosmosDbService.UpdateQuestionsAsync(id, program);

            return Ok(updatedProgram);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProgram(string id)
        {
            await _cosmosDbService.DeleteProgramAsync(id);

            return NoContent();
        }

        // GET Endpoint to fetch questions for a specific program (Screen 2)
        [HttpGet("{programId}/questions")]
        public async Task<IActionResult> GetQuestionsForProgram(string programId)
        {
            var program = await _cosmosDbService.GetProgramAsync(programId);

            if (program == null)
            {
                return NotFound();
            }

            return Ok(program.Questions); // Return the questions for the program
        }

        */
    }
}