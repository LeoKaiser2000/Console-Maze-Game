using System;
using System.Collections.Generic;
using System.Linq;
using Homework_2_Labyrinth_LeoKaiser.MazeGame.Tools;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.Scenes
{
    public class MazeResolveScene : IScene
    {
        private const string SceneName = "MazeResolveScene";
        
        private const string EnteringRoomMessage = "You arrived in room:";
        private const string LinkedRoomMessage = "In front of you, a panel, showing the connected rooms.";
        private const string QuestionMessage = "Which room would you like to enter ?";
        private const string NumberMoveMessage = "You reached the exit in";
        private const string BestSolutionFindMessage = "Congratulation, you did it in the fiewest moves !";
        private const string BestSolutionMessage = "The best solution was";
        private readonly string[] _continuePossibilities = { "Select another level", "Back to menu"};
        private const string ContinueQuestion = "Do you want to play another level ?";
        private const string InvalidMazeMessage = "Impossible to build maze.";
        private const string UnsolvableMazeMessage = "This level is unsolvable.";
        private const string SelectAnotherMessage = "Please select another.";

        private SceneManager _sceneManager;

        private readonly Maze _maze;
        private int _moveNumber;
        private List<Room> _bestSolution;
        private Room _playerPosition;

        public MazeResolveScene(string mazePath)
        {
            _maze = MazeBuilder.MazeBuilder.BuildMaze(mazePath);
        }

        public string Name() => SceneName;

        public void Start(SceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            _moveNumber = 0;
            if (_maze == null)
            {
                Console.WriteLine($"{InvalidMazeMessage} {SelectAnotherMessage}");
                throw new Exception();
            }

            _bestSolution = MazeSolver.MazeSolver.SolveMaze(_maze);
            if (_bestSolution is null)
            {
                Console.WriteLine($"{UnsolvableMazeMessage} {SelectAnotherMessage}");
                throw new Exception();
            }

            _playerPosition = _maze.Start;
        }

        public void Loop()
        {
            if (PlayerOnExit())
                LevelComplete();
            else
                PlayerTurn();
        }

        private bool PlayerOnExit()
        {
            return _maze.End.Contains(_playerPosition);
        }

        private void LevelComplete()
        {
            Console.WriteLine($"{NumberMoveMessage} {_moveNumber} move.");
            if (_moveNumber == _bestSolution.Count - 1)
                Console.WriteLine(BestSolutionFindMessage);
            else if (_moveNumber > _bestSolution.Count - 1)
                Console.WriteLine($"{BestSolutionMessage} {string.Join(" => ", _bestSolution.Select(room => room.Name))}.");
            _sceneManager.PopScene();
            switch (ConsoleInterpreter.AskToUserWithNumber(ContinueQuestion, _continuePossibilities))
            {
                case 0:
                    break;
                case 1:
                    _sceneManager.PopScene();
                    break;
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine($"{EnteringRoomMessage} {_playerPosition.Name}.");
            var question = LinkedRoomMessage + Environment.NewLine + QuestionMessage;
            var possibilities  = _playerPosition.ConnectedRooms.Select(room => room.Name);
            var userAnswer = ConsoleInterpreter.AskToUserWithNumber(question, possibilities.ToList());
            _playerPosition = _playerPosition.ConnectedRooms[userAnswer];
            ++_moveNumber;
        }
    }
}