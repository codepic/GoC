using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChoice.Services
{
    public class GameContext : DbContext
    {
        public GameContext()
        {

        }

        public GameContext(DbContextOptions<GameContext> options)
        {
            
        }

        public DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("MyDatabase2124");
            }
        }
    }
}
