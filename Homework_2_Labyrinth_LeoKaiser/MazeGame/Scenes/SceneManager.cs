using System;
using System.Collections.Generic;
using System.Linq;
using Homework_2_Labyrinth_LeoKaiser.MazeGame.Tools.Exceptions;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.Scenes
{
    public class SceneManager
    {
        private readonly Stack<IScene> _sceneStack;

        public SceneManager()
        {
            _sceneStack = new Stack<IScene>();
        }

        public void PushScene(IScene scene)
        {
            try
            {
                scene.Start(this);
            }
            catch
            {
                Console.WriteLine($"Error while loading scene {scene.Name()}");
                throw;
            }
            _sceneStack.Push(scene);
        }

        public void PopScene()
        {
            if (_sceneStack.Count > 0)
                _sceneStack.Pop();
        }
        
        public void Loop()
        {
            while (_sceneStack.Count > 0)
            {
                try
                {
                    _sceneStack.First().Loop();
                }
                catch (EndOfGameException)
                {
                    _sceneStack.Clear();
                }
                catch
                {
                    // ignored
                }
            }
        }
    }
}