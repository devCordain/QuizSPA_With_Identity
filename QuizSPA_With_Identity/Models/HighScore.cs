using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuizSPA_With_Identity
{
    public class HighScore
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public int Score { get; set; }
    }
}
