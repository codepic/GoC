using System;

namespace GameOfChoice.Services
{
    public class Game
    {
        public string Id { get; set; }
        public string Player { get; set; }
        public string Challenger { get; set; }
        public int PlayerChoice { get; set; }
        public int ChallengerChoice { get; set; }

        public Game()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}