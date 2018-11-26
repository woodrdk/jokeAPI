using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProgrammingJokeService.Models
{   
    /// <summary>
    /// CRUD Functionality for Jokes
    /// </summary>
    public static class JokeDb
    {
        /// <summary>
        /// Retrieves all Jokes from the database.
        /// </summary>
        public static async Task<List<Joke>> GetAllJokes(JokeDbContext _db)
        {
            return await _db.Jokes.ToListAsync();
        }

        /// <summary>
        /// Get all jokes by Category
        /// </summary>
        /// <param name="category">What category of the joke we are looking for</param>
        public static List<Joke> JokesByCategory(string category, JokeDbContext _db)
        {
            return (from j in _db.Jokes
                    where j.Category == category
                    select j).ToList();
        }

        public static void addJoke(JokeDbContext _db, Joke newData)
        {
            _db.Jokes.Add(newData);
            _db.SaveChanges();
        }

        public static void UpdateJoke(JokeDbContext _db, int JokeId, string jokeText, string jokeCategory)
        {
            Joke j = _db.Jokes.Find(JokeId);

            _db.Jokes.Attach(j).State = EntityState.Modified;
            j.JokeText = jokeText;
            j.Category = jokeCategory;
            _db.SaveChanges();
        }

        public static void DeleteJoke(JokeDbContext _db, int jokeId)
        {
            Joke j = _db.Jokes.Find(jokeId); // find joke and start tracking
             _db.Jokes.Remove(j);           // marks joke as deleted
            _db.SaveChanges();              // saves to database
        }

        public static bool DoesExist(JokeDbContext _db, int id)
        {
            // returns the true if the jokeId exists in the database.
            return _db.Jokes.Where(j => j.JokeId == id).Any();

        }
    }
}
