using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizSPA_With_Identity
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<HighScore> HighScores { get; set; }
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    Text = "What greek god carries a trident, and stirs up hurricanes when he gets grumpy?"
                },
                new Question
                {
                    Id = 2,
                    Text = "What is Hephaestus known for?"
                },
                new Question
                {
                    Id = 3,
                    Text = "Of what is Nemesis the godess of?"
                });
            builder.Entity<Answer>().HasData(
                    new Answer { Id = 1, QuestionId = 1, Text = "Zeus", IsCorrect = false },
                    new Answer { Id = 2, QuestionId = 1, Text = "Hephaestus", IsCorrect = false },
                    new Answer { Id = 3, QuestionId = 1, Text = "Poseidon", IsCorrect = true },
                    new Answer { Id = 4, QuestionId = 1, Text = "Apollo", IsCorrect = false },
                    new Answer { Id = 5, QuestionId = 2, Text = "Making cool stuff in a volcano", IsCorrect = true },
                    new Answer { Id = 6, QuestionId = 2, Text = "Flying", IsCorrect = false },
                    new Answer { Id = 7, QuestionId = 2, Text = "Slaying mythical creatures", IsCorrect = false },
                    new Answer { Id = 8, QuestionId = 2, Text = "Running really fast", IsCorrect = false },
                    new Answer { Id = 9, QuestionId = 3, Text = "Mythical creatures", IsCorrect = false },
                    new Answer { Id = 10, QuestionId = 3, Text = "Lightning", IsCorrect = false },
                    new Answer { Id = 11, QuestionId = 3, Text = "Bad harvests", IsCorrect = false },
                    new Answer { Id = 12, QuestionId = 3, Text = "Revenge", IsCorrect = true }
                    );
            
                builder.Entity<HighScore>().HasData(
                 new HighScore
                 {
                     Id = 1, 
                     UserName = "The Literal God of Quiz",
                     Score = 1000
                 },
                 new HighScore
                 {
                     Id = 2, 
                     UserName = "50 monkeys on a typewriter",
                     Score = 0
                 },
                 new HighScore
                 {
                     Id = 3,
                     UserName = "Donald Trump",
                     Score = 1
                 },
                 new HighScore
                 {
                     Id = 4, 
                     UserName = "Cat walked on keyboard",
                     Score = 3
                 });
            base.OnModelCreating(builder);
        }
    }
}
