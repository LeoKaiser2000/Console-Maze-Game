using System.Collections.Generic;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame
{
    public class Room
    {
        public string Name = "";
        public readonly List<Room> ConnectedRooms = new List<Room>();
    }
}