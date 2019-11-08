using GameOfChoice.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfChoice.Tests
{
    public class GameDbFixture : IDisposable
    {
        private DbContextOptions<GameContext> _options;

        public GameContext GameContext { get; private set; }
        public string DbName { get; }

        public GameDbFixture()
        {
            DbName = Guid.NewGuid().ToString();
            _options = new DbContextOptionsBuilder<GameContext>()
                .UseInMemoryDatabase(DbName)
                .Options;
            GameContext = new GameContext(_options);
        }

        internal void CreateGame()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GameContext.Dispose();
        }
    }
}
