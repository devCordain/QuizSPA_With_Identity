using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QuizSPA_With_Identity
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HighScoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HighScoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/HighScores
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HighScore>>> GetHighScore()
        {
            return await _context.HighScores.OrderByDescending(x => x.Score).ToListAsync();
        }

        // GET: api/HighScores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HighScore>> GetHighScore(int id)
        {
            var highScore = await _context.HighScores.FindAsync(id);

            if (highScore == null)
            {
                return NotFound();
            }

            return highScore;
        }

        // PUT: api/HighScores/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHighScore(int id, HighScore highScore)
        {
            if (id != highScore.Id)
            {
                return BadRequest();
            }

            _context.Entry(highScore).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HighScoreExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/HighScores
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<HighScore>> PostHighScore(HighScore highScore)
        {
            _context.HighScores.Add(highScore);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHighScore", new { id = highScore.Id }, highScore);
        }

        // DELETE: api/HighScores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<HighScore>> DeleteHighScore(int id)
        {
            var highScore = await _context.HighScores.FindAsync(id);
            if (highScore == null)
            {
                return NotFound();
            }

            _context.HighScores.Remove(highScore);
            await _context.SaveChangesAsync();

            return highScore;
        }

        private bool HighScoreExists(int id)
        {
            return _context.HighScores.Any(e => e.Id == id);
        }
    }
}
