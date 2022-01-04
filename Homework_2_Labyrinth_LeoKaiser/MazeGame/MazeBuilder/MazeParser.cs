using System;
using System.IO;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.MazeBuilder
{
    public static class MazeParser
    {
        private static void AppendRoom(MazeScheme maze, RoomScheme newRoom)
        {
            if (maze.Rooms.Exists(room => room.Name == newRoom.Name))
                throw new Exception($"Room {newRoom.Name} is already defined");
            maze.Rooms.Add(newRoom);
        }
        
        private static void ReadStart(MazeScheme maze, string line)
        {
            if (maze.StartRoomName != null)
                throw new Exception("Maze start already defined");
            var roomName = line[MazeFileFormat.StartToken.Length..];
            if (roomName.Length == 0)
                throw new Exception("Start room name is empty");
            maze.StartRoomName = roomName;
        }
        private static void ReadEnd(MazeScheme maze, string line)
        {
            var roomName = line[MazeFileFormat.EndToken.Length..];

            if (maze.EndRoomNames.Contains(roomName))
                throw new Exception($"Maze end point {roomName} is already defined");
            if (roomName.Length == 0)
                throw new Exception("Maze room name is empty");
            maze.EndRoomNames.Add(roomName);
        }
        
        private static void ReadLink(MazeScheme maze, string line)
        {
            var split = line.Split(MazeFileFormat.RoomContentToken);
            if (split.Length != 2)
                throw new Exception("Too many split tokens");
            var roomName = split[0];
            if (roomName.Length == 0)
                throw new Exception("Maze room name is empty");
            var connectedRoomNames = split[1].Split(MazeFileFormat.RoomSpacerToken);
            AppendRoom(maze, new RoomScheme {Name = roomName, ConnectedRoomNames = connectedRoomNames});
        }

        public static MazeScheme BuildMazeScheme(string inputFileName)
        {
            var lineCount = 0;
            try
            {
                var newMaze = new MazeScheme();
                var lines = File.ReadAllLines(inputFileName);
                foreach (var line in lines)
                {
                    ++lineCount;
                    if (line.StartsWith(MazeFileFormat.StartToken))
                        ReadStart(newMaze, line);
                    else if (line.StartsWith(MazeFileFormat.EndToken))
                        ReadEnd(newMaze, line);
                    else
                        ReadLink(newMaze, line);
                }
                return newMaze;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine(lineCount != 0 ? $"Parsing error line {lineCount}: {e.Message}" : $"Parsing error: {e.Message}");
                throw;
            }
        }
    }
}