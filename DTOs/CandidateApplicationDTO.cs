using Capital.Models;
using System.Collections.Generic;

namespace Capital.DTOs
{
    public class CandidateApplicationDTO
    {
        public required string Name { get; set; }
        public required Dictionary<int, string> QuestionResponses { get; set; }
        // Need Add additional properties as needed based
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public required string Nationality { get; set; }
        public required string CurrentResidence { get; set; }
        public required string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string Gender { get; set; }
        public int? YearOfGraduation { get; set; } // Added to store Year of Graduation
        public required string AboutYourself { get; set; } // Added to store "Tell us about yourself"
        public bool UkEmbassyRejection { get; set; } // Added to store UK Embassy rejection status
        public List<string> SelectedKeywords { get; set; } = new List<string>(); // Added to store selected keywords
        public List<Answer> Answers { get; set; } = new List<Answer>(); // To store answers from the application form
    }
}
