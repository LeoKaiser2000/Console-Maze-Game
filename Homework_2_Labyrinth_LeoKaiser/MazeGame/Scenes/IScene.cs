namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.Scenes
{
    public interface IScene
    {
        public string Name();
        public void Start(SceneManager sceneManager);
        public void Loop();
    }
}