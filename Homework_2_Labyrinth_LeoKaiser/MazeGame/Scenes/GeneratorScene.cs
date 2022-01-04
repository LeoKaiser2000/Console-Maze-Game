using System;
using System.Linq;
using Homework_2_Labyrinth_LeoKaiser.MazeGame.MazeGenerator;
using Homework_2_Labyrinth_LeoKaiser.MazeGame.Tools;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.Scenes
{
    public class GeneratorScene : IScene
    {
        private const string SceneName = "GeneratorScene";
        private SceneManager _sceneManager;
        private readonly string[] _showSolutionPossibilities = { "Do not show", "Show only minimal move number", "Show minimal move number and solution"};
        private const string ShowSolutionQuestion = "Do you want to show minimal move number or solution ?";
        private readonly string[] _continuePossibilities = { "Generate another", "Back to menu"};
        private const string ContinueQuestion = "Do you want to generate another maze ?";
        private const string FilePathQuestion = "Enter the name of new level:";
        private const string RoomNamesQuestion = "Enter the name of evey rooms, separated by spaces:";
        private const string StartRoomQuestion = "Enter the name of starting room:";
        private const string EndRoomsQuestions = "Enter the name of evey ends, separated by spaces:";
        private const string RandomRateQuestion = "Enter random link rate (number from 0 to 100):";
        private const string NotAValidNumberMessage = "Please enter a valid number";
        private const string NumberOfMoveString = "Maze can be solved in";
        private const string GeneratorErrorMessage = "Generator error";
        private const string GenerationErrorMessage = "Generation error";
        private const string UnsolvableMazeMessage = "maze can not be solved";


        public string Name() => SceneName;

        public void Start(SceneManager sceneManager)
        {
            _sceneManager = sceneManager;
        }

        public void Loop()
        {
            var filePath = ConsoleInterpreter.AskToUser(FilePathQuestion, null);
            var roomNames = ConsoleInterpreter.AskToUser(RoomNamesQuestion, null).Split(" ");
            var startName = ConsoleInterpreter.AskToUser(StartRoomQuestion, null);
            var endNames = ConsoleInterpreter.AskToUser(EndRoomsQuestions, null).Split(" ");
            int randomLinkRate;
            while (!int.TryParse(ConsoleInterpreter.AskToUser(RandomRateQuestion, null), out randomLinkRate))
                Console.WriteLine(NotAValidNumberMessage);
            try
            {
                var maze = MazeGenerator.MazeGenerator.GenerateMaze(roomNames, randomLinkRate, endNames, startName);
                if (maze == null)
                {
                    Console.WriteLine(GeneratorErrorMessage);
                    return;
                }
                                
                var solution = MazeSolver.MazeSolver.SolveMaze(maze);
                if (solution == null)
                {
                    Console.WriteLine($"{GeneratorErrorMessage}: {UnsolvableMazeMessage}");
                    return;
                }
                
                MazeWriter.WriteMazeInFile(maze, $"{MazeFileFormat.FolderPath}{filePath}{MazeFileFormat.Extension}");

                switch (ConsoleInterpreter.AskToUserWithNumber(ShowSolutionQuestion, _showSolutionPossibilities))
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine($"{NumberOfMoveString} {solution.Count - 1} moves");
                        break;
                    case 2:
                        Console.WriteLine($"{NumberOfMoveString} {solution.Count - 1} moves : {string.Join(" => ", solution.Select(room => room.Name))}");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine(GenerationErrorMessage);
                return;
            }
            switch (ConsoleInterpreter.AskToUserWithNumber(ContinueQuestion, _continuePossibilities))
            {
                case 0:
                    break;
                case 1:
                    _sceneManager.PopScene();
                    break;
            }

        }

    }
}