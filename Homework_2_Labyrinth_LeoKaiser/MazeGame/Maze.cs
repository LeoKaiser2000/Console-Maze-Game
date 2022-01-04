using System.Collections.Generic;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame
{
    public class Maze
    {
        public readonly List<Room> Rooms = new List<Room>();
        public Room Start = default;
        public readonly List<Room> End = new List<Room>();
    }
}