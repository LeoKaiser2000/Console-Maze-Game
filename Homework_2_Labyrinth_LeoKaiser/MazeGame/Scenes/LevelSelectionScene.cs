using System;
using System.Collections.Generic;
using System.IO;
using Homework_2_Labyrinth_LeoKaiser.MazeGame.Tools;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.Scenes
{
    public class LevelSelectionScene : IScene
    {
        private const string SceneName = "LevelSelectionScene";
        private FileInfo[] _levelFiles;
        private SceneManager _sceneManager;
        private readonly DirectoryInfo _levelDirectory = new DirectoryInfo(@MazeFileFormat.FolderPath);
        private readonly List<string> _levelNames = new List<string>();
        private const string LevelSelectionQuestion = "Witch level would you like to play ?";
        private const string LevelMotFoundMessage = "Game level error: no level found";

        public string Name() => SceneName;

        public void Start(SceneManager sceneManager)
        {
            _sceneManager = sceneManager;
            _levelFiles = _levelDirectory.GetFiles($"*{MazeFileFormat.Extension}");
            if (_levelFiles.Length == 0)
            {
                Console.WriteLine(LevelMotFoundMessage);
                throw new Exception();
            }
            foreach (var file in _levelFiles)
            {
                _levelNames.Add(file.Name.Replace(MazeFileFormat.Extension, ""));
            }
            _levelNames.Sort();
        }
        
        public void Loop()
        {
            var userAnswer = ConsoleInterpreter.AskToUserWithNumber(LevelSelectionQuestion, _levelNames);
            _sceneManager.PushScene(new MazeResolveScene(MazeFileFormat.FolderPath + _levelNames[userAnswer] + MazeFileFormat.Extension));
        }
    }
}