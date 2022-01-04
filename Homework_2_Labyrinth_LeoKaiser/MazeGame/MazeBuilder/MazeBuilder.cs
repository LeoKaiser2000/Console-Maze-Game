using System;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.MazeBuilder
{
    public static class MazeBuilder
    {

        private static void AddRooms(Maze maze, MazeScheme scheme)
        {
            foreach (var roomScheme in scheme.Rooms)
            {
                maze.Rooms.Add(new Room {Name = roomScheme.Name} );
            }
        }

        private static void FillRooms(Maze maze, MazeScheme scheme)
        {
            foreach (var roomScheme in scheme.Rooms)
            {
                var newRoom = maze.Rooms.Find(room => room.Name == roomScheme.Name);
                if (newRoom is null)
                    throw new Exception("Internal error");

                foreach (var connectedRoomName in roomScheme.ConnectedRoomNames)
                {
                    var connectedRoom = maze.Rooms.Find(room => room.Name == connectedRoomName);
                    if (connectedRoom is null)
                        throw new Exception($"Room {connectedRoomName} connected to room {roomScheme.Name} does not exist");
                    if (newRoom.ConnectedRooms.Exists(room => room.Name == connectedRoomName))
                        throw new Exception($"Room {connectedRoomName} is already link to room {roomScheme.Name}");
                    newRoom.ConnectedRooms.Add(connectedRoom);
                }

                maze.Rooms.Add(newRoom);
            }
        }

        private static void SetBegin(Maze maze, MazeScheme scheme)
        {
            if (scheme.StartRoomName is null)
                throw new Exception("Maze begin is missing");
            var beginRoom = maze.Rooms.Find(room => room.Name == scheme.StartRoomName);
            if (beginRoom is null)
                throw new Exception($"Room begin {scheme.StartRoomName} does not exist");
            maze.Start = beginRoom;
        }
        
        private static void SetEnd(Maze maze, MazeScheme scheme)
        {
            if (scheme.EndRoomNames.Count == 0)
                throw new Exception("Maze end is missing");
            foreach (var endNames in scheme.EndRoomNames)
            {
                var endRoom = maze.Rooms.Find(room => room.Name == endNames);
                if (endRoom is null)
                    throw new Exception($"Room end {endNames} does not exist");
                maze.End.Add(endRoom);
            }
        }

        public static Maze BuildMaze(string inputFileName)
        {
            var scheme = MazeParser.BuildMazeScheme(inputFileName);
            var maze = new Maze();

            try
            {
                AddRooms(maze, scheme);
                FillRooms(maze, scheme);
                SetBegin(maze, scheme);
                SetEnd(maze, scheme);
                return maze;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Building error: {e.Message}");
                throw;
            }
        }
    }
}