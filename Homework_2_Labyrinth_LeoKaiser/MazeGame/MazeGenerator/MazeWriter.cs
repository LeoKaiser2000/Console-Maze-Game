using System;
using System.IO;
using System.Linq;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.MazeGenerator
{
    public static class MazeWriter
    {
        public static void WriteMazeInFile(Maze maze, string filePath)
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine($"Maze writer error: file {filePath} already exist");
                throw new Exception();
            }

            var streamWriter = File.CreateText(filePath);
            streamWriter.WriteLine($"{MazeFileFormat.StartToken}{maze.Start.Name}");
            foreach (var end in maze.End)
                streamWriter.WriteLine($"{MazeFileFormat.EndToken}{end.Name}");
            foreach (var room in maze.Rooms)
            {
                streamWriter.WriteLine($"{room.Name}{MazeFileFormat.RoomContentToken}{string.Join(MazeFileFormat.RoomSpacerToken, room.ConnectedRooms.Select(link => link.Name))}");
            }
            streamWriter.Close();
            
        }
    }
}