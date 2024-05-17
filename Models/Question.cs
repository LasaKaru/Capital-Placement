namespace Capital.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public required string QuestionText { get; set; }
        public QuestionType Type { get; set; }
        public List<string> Options { get; set; } = new List<string>();
    }
}
