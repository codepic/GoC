using GameOfChoice.Services;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace GameOfChoice.Tests
{
    public class GameServiceTests : IClassFixture<GameDbFixture>
    {
        const string PlayerName = "JaniHyytiäinen";
        const string ChallengerName = "JohnDoe";
        string GameId;

        private GameDbFixture Fixture { get; }

        public GameServiceTests(GameDbFixture fixture)
        {
            Fixture = fixture;
            var svc = new GameService(Fixture.GameContext);
            var game = svc.CreateGame();
            GameId = game.Id;
        }

        [Fact]
        public async void ShouldAddGameToService()
        {
            var ctx = Fixture.GameContext;
            Assert.Equal(1, ctx.Games.CountAsync().Result);
            var actual = await ctx.Games.SingleAsync();
            Assert.Equal(GameId, actual.Id);
        }

        [Theory]
        [InlineData(PlayerName)]
        public async void ShouldPlayGame(string playerName)
        {
            var ctx = Fixture.GameContext;
            var svc = new GameService(ctx);
            bool joined = svc.Play(GameId, playerName);
            Assert.True(joined);

            var actual = await ctx.Games.SingleAsync(g => g.Id.Equals(GameId));
            Assert.Equal(playerName, actual.Player);
        }

        [Theory]
        [InlineData(ChallengerName)]
        public async void ShouldChallengeGame(string playerName)
        {
            var ctx = Fixture.GameContext;
            var svc = new GameService(ctx);
            bool joined = svc.Challenge(GameId, playerName);
            Assert.True(joined);

            var actual = await ctx.Games.SingleAsync(g => g.Id.Equals(GameId));
            Assert.Equal(playerName, actual.Challenger);
        }

        [Theory]
        [InlineData(PlayerName, Choices.Choice.Rock)]
        public async void PlayerShouldCooseInGame(string playerName, Choices.Choice choice)
        {
            var ctx = Fixture.GameContext;
            var svc = new GameService(ctx);
            svc.Play(GameId, playerName);
            bool chosen = svc.Choose(GameId, playerName, choice);
            Assert.True(chosen);

            var actual = await ctx.Games.SingleAsync(g => g.Id.Equals(GameId));
            Assert.True(Convert.ToInt32(choice) == actual.PlayerChoice);
        }

        [Theory]
        [InlineData(ChallengerName, Choices.Choice.Scissors)]
        public async void ChallengerShouldCooseInGame(string challengerName, Choices.Choice choice)
        {
            var ctx = Fixture.GameContext;
            var svc = new GameService(ctx);
            svc.Challenge(GameId, challengerName);
            bool chosen = svc.Choose(GameId, challengerName, choice);
            Assert.True(chosen);

            var actual = await ctx.Games.SingleAsync(g => g.Id.Equals(GameId));
            Assert.True(Convert.ToInt32(choice) == actual.ChallengerChoice);
        }


    }
}
