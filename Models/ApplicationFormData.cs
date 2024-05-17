namespace Capital.Models
{
    public class ApplicationFormData
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public int? YearOfGraduation { get; set; } // Added to store Year of Graduation
        public string AboutYourself { get; set; } // Added to store "Tell us about yourself"
        public bool UkEmbassyRejection { get; set; } // Added to store UK Embassy rejection status
        public List<string> SelectedKeywords { get; set; } = new List<string>(); // Added to store selected keywords
        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}