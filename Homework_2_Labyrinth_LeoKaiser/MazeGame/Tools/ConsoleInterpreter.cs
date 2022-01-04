using System;
using System.Collections.Generic;
using Homework_2_Labyrinth_LeoKaiser.MazeGame.Tools.Exceptions;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.Tools
{
    public static class ConsoleInterpreter
    {
        private const string QuitMessage = "quit";
        private const string QuitAccept = "y";
        private const string QuitDismiss = "n";
        private static readonly string QuitQuestion = $"Do you really want to quit ({QuitAccept}/{QuitDismiss})?";

        public static void CloseQuestion()
        {
            if (AskToUserWithoutQuit(QuitQuestion,
                    new List<string> { QuitAccept, QuitDismiss }) == QuitAccept)
                throw new EndOfGameException();
        }


        public static string AskToUserWithoutQuit(string question, ICollection<string> authorizedAnswer)
        {
            Console.WriteLine(question);
            var input = Console.ReadLine();
            if (authorizedAnswer == null || authorizedAnswer.Count == 0) return input;
            while (!authorizedAnswer.Contains(input))
            {
                Console.WriteLine($"Invalid answer {input}");
                Console.WriteLine(question);
                input = Console.ReadLine();
            }
            return input;
        }
        
        public static string AskToUser(string question, ICollection<string> authorizedAnswer)
        {
            Console.WriteLine(question);
            var input = Console.ReadLine();
            if (input == QuitMessage)
                CloseQuestion();
            if (authorizedAnswer == null || authorizedAnswer.Count == 0) return input;
            while (!authorizedAnswer.Contains(input))
            {
                if (input == QuitMessage)
                    CloseQuestion();
                Console.WriteLine($"Invalid answer {input}");
                Console.WriteLine(question);
                input  = Console.ReadLine();
            }
            return input;
        }

        public static int AskToUserWithNumber(string question, IList<string> possibilities)
        {
            var authorizedAnswer = new List<string>();
            if (possibilities == null || possibilities.Count == 0)
                throw new ArgumentNullException();
            for (var i = 0; i < possibilities.Count; i++)
            {
                question += $"{Environment.NewLine}{i + 1}) {possibilities[i]}";
                authorizedAnswer.Add((i + 1).ToString());
            }

            return int.Parse(AskToUser(question, authorizedAnswer)) - 1;
        }
    }
}