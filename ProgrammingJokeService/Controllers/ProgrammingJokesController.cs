using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingJokeService.Models;

namespace ProgrammingJokeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingJokesController : ControllerBase
    {
        // only constructor can modify a readonly field
        private readonly JokeDbContext _db;
        public ProgrammingJokesController(JokeDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetJoke()
        {
            List<Joke> jokes = await _db.Jokes.ToListAsync();

            return Ok(jokes);
        }

        // mywebsite.com/api/ProgrammingJokes/category/C#
        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetJokesByCategory([FromRoute]string category)
        {
            List<Joke> jokesCat = (from j in _db.Jokes
                                   where j.Category == category
                                   select j).ToList();


               //await _db.Jokes.ToListAsync();

            return Ok(jokesCat);
        }
    }
}