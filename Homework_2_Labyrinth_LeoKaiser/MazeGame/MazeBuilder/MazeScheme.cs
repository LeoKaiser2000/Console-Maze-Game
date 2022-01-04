using System.Collections.Generic;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.MazeBuilder
{
    public class MazeScheme
    {
        public string StartRoomName = null;
        public readonly List<string> EndRoomNames = new List<string>();
        public readonly List<RoomScheme> Rooms = new List<RoomScheme>();
    }
}