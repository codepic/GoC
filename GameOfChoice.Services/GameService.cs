using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfChoice.Services
{
    public class GameService : IGameService
    {
        GameContext _context;

        public GameService(GameContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> List() => _context.Games.ToList();

        public Game Get(string id)
        {
            return _context.Games.FirstOrDefault(g => g.Id == id);
        }

        public Game CreateGame()
        {
            var game = new Game();
            _context.Games.Add(game);
            _context.SaveChanges();
            return game;
        }

        public bool Play(string id, string playerName)
        {
            var game = GetGame(id);
            game.Player = playerName;
            _context.Games.Update(game);
            _context.SaveChanges();
            return true;
        }

        public bool Challenge(string id, string playerName)
        {
            var game = GetGame(id);
            game.Challenger = playerName;
            _context.Games.Update(game);
            _context.SaveChanges();
            return true;
        }

        public bool Choose(string id, string playerName, Choices.Choice choice)
        {
            var game = GetGame(id);

            if (!string.IsNullOrEmpty(game.Player) && game.Player.Equals(playerName, StringComparison.OrdinalIgnoreCase))
            {
                game.PlayerChoice = Convert.ToInt32(choice);
            }
            else
            {
                game.ChallengerChoice = Convert.ToInt32(choice);
            }


            _context.Games.Update(game);
            _context.SaveChanges();
            return true;
        }

        private Game GetGame(string id)
        {
            var game = _context.Games.FirstOrDefault(g => g.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            return game;
        }

        public string Winner(string id)
        {
            var game = GetGame(id);
            var player = (Choices.Choice)game.PlayerChoice;
            var challenger = (Choices.Choice)game.ChallengerChoice;

            bool playerWins = new PlayerChoice(player).Wins(challenger);

            return (playerWins)
                ? "Player"
                : "Challenger";
        }
    }
}