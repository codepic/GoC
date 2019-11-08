using GameOfChoice.Services;
using System;
using Xunit;

namespace GameOfChoice.Tests
{
    public class ServicTests
    {
        [Theory]
        [InlineData(Choices.Choice.Rock, Choices.Choice.Scissors)]
        [InlineData(Choices.Choice.Paper, Choices.Choice.Rock)]
        [InlineData(Choices.Choice.Scissors, Choices.Choice.Paper)]
        public void PlayerShouldWinChallenger(Choices.Choice player, Choices.Choice challenger)
        {
            var playerChoice = new PlayerChoice(player);

            Assert.True(playerChoice.Wins(challenger));
        }

        [Theory]
        [InlineData(Choices.Choice.Rock, Choices.Choice.Paper)]
        [InlineData(Choices.Choice.Paper, Choices.Choice.Scissors)]
        [InlineData(Choices.Choice.Scissors, Choices.Choice.Rock)]
        public void PlayerShouldLoseChallenger(Choices.Choice player, Choices.Choice challenger)
        {
            var challengerChoice = new PlayerChoice(challenger);

            Assert.True(challengerChoice.Wins(player));
        }

        [Theory]
        [InlineData(Choices.Choice.Rock, Choices.Choice.Rock)]
        [InlineData(Choices.Choice.Paper, Choices.Choice.Paper)]
        [InlineData(Choices.Choice.Scissors, Choices.Choice.Scissors)]
        public void NoneSouldWinWhenDraw(Choices.Choice player, Choices.Choice challenger)
        {
            Assert.False(new PlayerChoice(player).Wins(challenger));
            Assert.False(new PlayerChoice(challenger).Wins(player));
        }
    }
}
