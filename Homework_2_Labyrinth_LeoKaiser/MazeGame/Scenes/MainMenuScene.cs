using System;
using Homework_2_Labyrinth_LeoKaiser.MazeGame.Tools;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.Scenes
{
    public class MainMenuScene : IScene
    {
        private const string SceneName = "MainMenuScene";
        private SceneManager _sceneManager;

        private const string WelcomeMessage =
            "Hello, and welcome to AMAZEING, where all amazing maze will make you crazy. Notice that you can leave can from anywhere by writing \"quit\"";

        private const string Question = "What would you like to do ?";
        private readonly string[] _possibilities = { "Play", "Generate a level", "Leave Game"};


        public string Name() => SceneName;

        public void Start(SceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            Console.WriteLine(WelcomeMessage);

        }

        public void Loop()
        {
            var userAnswer = ConsoleInterpreter.AskToUserWithNumber(Question, _possibilities);
            switch (userAnswer)
            {
                case 0:
                    _sceneManager.PushScene(new LevelSelectionScene());
                    break;
                case 1:
                    _sceneManager.PushScene(new GeneratorScene());
                    break;
                case 2:
                    ConsoleInterpreter.CloseQuestion();
                    break;
            }
        }
    }
}