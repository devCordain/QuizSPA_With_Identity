using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuizSPA_With_Identity
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        [ForeignKey("QuestionId")]
        public virtual int QuestionId { get; set; }
    }
}
