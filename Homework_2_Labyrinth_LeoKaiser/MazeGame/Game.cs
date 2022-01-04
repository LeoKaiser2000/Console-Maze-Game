using System;
using Homework_2_Labyrinth_LeoKaiser.MazeGame.Scenes;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame
{
    public static class Game
    {
        public static void Play()
        {
            var sceneManager = new SceneManager();
            sceneManager.PushScene(new MainMenuScene());
            sceneManager.Loop();
            Console.WriteLine("Good bye");
        }
    }
}