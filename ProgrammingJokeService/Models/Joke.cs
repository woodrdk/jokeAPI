using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingJokeService.Models
{
    /// <summary>
    /// Represents a single programming joke
    /// </summary>
    public class Joke
    {
        [Key]
        public int JokeId { get; set; }

        /// <summary>
        /// The actual text of the joke
        /// </summary>
        public string JokeText { get; set; }

        /// <summary>
        /// Category of joke ex. Programming, Database
        /// </summary>
        public string Category { get; set; }

    }
}
