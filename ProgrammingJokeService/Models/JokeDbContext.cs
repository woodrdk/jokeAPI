using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingJokeService.Models
{
    public class JokeDbContext : DbContext
    {
        public JokeDbContext(DbContextOptions<JokeDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Joke> Jokes { get; set; }
    }

    
}
