using Microsoft.AspNetCore.Mvc;
using Capital.DTOs;
using System;
using System.Collections.Generic;
using Capital.Models;

namespace Capital.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateApplicationController : ControllerBase
    {

        //private readonly ICosmosDbService _cosmosDbService;

        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Email { get; private set; }

        // POST endpoint for candidate application submission
        [HttpPost]
        public IActionResult Post([FromBody] CandidateApplicationDTO applicationDTO)
        {
            // Implement logic to process candidate application
            Console.WriteLine($"Received application from candidate: {applicationDTO.Name}");

            foreach (var kvp in applicationDTO.QuestionResponses)
            {
                Console.WriteLine($"Question ID: {kvp.Key}, Response: {kvp.Value}");
            }

            // Here you can further process the application data, save it to the database, etc.
            return Ok("Candidate application received successfully");
        }

        // GET endpoint for fetching questions
        [HttpGet("questions")]
        public IActionResult GetQuestions()
        {
            // Mock data for demonstration purposes
            var questions = new List<QuestionDTO>
            {
                new QuestionDTO { Id = 1, Text = "What is your preferred programming language?" },
                new QuestionDTO { Id = 2, Text = "How many years of experience do you have?" },
                // Add more questions as needed
            };

            return Ok(questions);
        }


        /*
        [HttpPost]
        public async Task<IActionResult> CreateCandidateApplication([FromBody] CandidateApplicationDTO applicationDto)
        {
            // Map DTO to Model
            var application = new ApplicationFormData();
            {
                FirstName = applicationDto.FirstName;
                LastName = applicationDto.LastName;
                Email = applicationDto.Email;
                Phone = applicationDto.Phone,
                Nationality = applicationDto.Nationality;
                CurrentResidence = applicationDto.CurrentResidence;
                IdNumber = applicationDto.IdNumber,
                DateOfBirth = applicationDto.DateOfBirth,
                Gender = applicationDto.Gender,
                YearOfGraduation = applicationDto.YearOfGraduation,
                AboutYourself = applicationDto.AboutYourself,
                UkEmbassyRejection = applicationDto.UkEmbassyRejection,
                SelectedKeywords = applicationDto.SelectedKeywords,
                Answers = applicationDto.Answers
            };

            // Save to Cosmos DB
            var createdApplication = await _cosmosDbService.CreateCandidateApplicationAsync(application);

            return CreatedAtAction(nameof(GetCandidateApplication), new { id = createdApplication.Id }, createdApplication);
        }

        */
        
        

    }
}
