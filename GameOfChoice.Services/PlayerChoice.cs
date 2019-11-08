using System;

namespace GameOfChoice.Services
{
    public class PlayerChoice
    {
        private Choices.Choice _choice;

        public PlayerChoice(Choices.Choice choice)
        {
            _choice = choice;
        }

        public bool Wins(Choices.Choice choice)
        {
            if (Choices.IsGreatest(choice))
                return _choice < choice;
            return _choice > choice;
        }
    }
}
