using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfChoice.Services
{
    public class Choices
    {
        [Flags]
        public enum Choice
        {
            Rock = 1 << 1,
            Paper = 1 << 2,
            Scissors = 1 << 3
        }

        internal static bool IsGreatest(Choice choice)
        {
            return choice == Enum.GetValues(typeof(Choice)).Cast<Choice>().Last();
        }
    }
}
