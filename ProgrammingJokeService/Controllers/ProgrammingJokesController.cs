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
            List<Joke> jokes = await JokeDb.GetAllJokes(_db);

            return Ok(jokes);
        }

      

        // mywebsite.com/api/ProgrammingJokes/category/C#
        [HttpGet("category/{category}")]
        public IActionResult GetJokesByCategory([FromRoute]string category)
        {
            List<Joke> jokesCat = JokeDb.JokesByCategory(category, _db);

            return Ok(jokesCat);
        }

        // to add joke to db
        [HttpPost]
        public IActionResult PostJoke([FromBody] Joke j)
        {
            if (ModelState.IsValid)
            {
                JokeDb.addJoke(_db, j);
                return Ok();
            }
            else
            {
                // return http 400, with modelstate errors
                return BadRequest(ModelState); //throw new Exception("test");
            }
        }

        // mywebsite.com/api/programmingjokes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteJoke([FromRoute] int id)
        {
            if (JokeDb.DoesExist(_db, id))
            {
                JokeDb.DeleteJoke(_db, id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // mywebsite.com/api/programmingjokes/5
        [HttpPut("{id}")]
        public IActionResult UpdateOldJoke([FromRoute] int id, string jokeText, string jokeCategory)
        {
            if (JokeDb.DoesExist(_db, id))
            {
                JokeDb.UpdateJoke(_db, id, jokeText, jokeCategory);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

    }
}