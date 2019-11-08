namespace GameOfChoice.Services
{
    public interface IGameService
    {
        bool Challenge(string gameId, string playerName);
        bool Choose(string gameId, string playerName, Choices.Choice choice);
        Game CreateGame();
        Game Get(string id);
        System.Collections.Generic.IEnumerable<Game> List();
        bool Play(string gameId, string playerName);
        string Winner(string id);
    }
}