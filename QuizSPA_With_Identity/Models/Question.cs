using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuizSPA_With_Identity
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
    }
}
