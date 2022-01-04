using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.MazeGenerator
{
    public static class MazeGenerator
    {
        [return:MaybeNull]
        public static Maze GenerateMaze(ICollection<string> roomNames, int randomLinkRate, ICollection<string> roomEnds, string roomStart)
        {
            var randomSeed = new Random();
            var maze = new Maze();
            if (roomNames.FirstOrDefault(room => string.Equals(room, roomStart)) is null)
            {
                Console.WriteLine($"The start {roomStart} is not in room list");
                return null;
            }

            foreach (var end in roomEnds)
            {
                if (roomNames.FirstOrDefault(room => string.Equals(room, end)) is null)
                {
                    Console.WriteLine($"The end {end} is not in room list");
                    return null;
                }
            }
            if (roomEnds.Count < 1)
            {
                Console.WriteLine("The number of end can't be less than 1");
                return null;
            }
            if (randomLinkRate < 0)
            {
                Console.WriteLine("Generator error: The number minimum link can't be less than 0");
                return null;
            }
            if (randomLinkRate > 100)
            {
                Console.WriteLine("Generator error: The number maximum link can't be greater than 100");
                return null;
            }
            
            foreach (var roomName in roomNames)
            {
                if (maze.Rooms.Exists(room => string.Equals(room.Name, roomName)))
                {
                    Console.WriteLine($"Generator error: Duplicate room {roomName}");
                    return null;
                }
                var newRoom = new Room { Name = roomName };
                maze.Rooms.Add(newRoom);
                if (roomEnds.FirstOrDefault(end => string.Equals(end, roomName)) != null)
                    maze.End.Add(newRoom);
                if (string.Equals(roomName, roomStart))
                    maze.Start = newRoom;
            }

            var remainingRoomStack = new Queue<Room>(maze.Rooms);
            var toLinkStack = new Queue<Room>();
            toLinkStack.Enqueue(remainingRoomStack.Dequeue());
            while (toLinkStack.Count > 0 && remainingRoomStack.Count > 0)
            {
                var toLink = toLinkStack.Dequeue();
                for (var i = 0; i < 2 && remainingRoomStack.Count > 0; ++i)
                {
                    var remain = remainingRoomStack.Dequeue();
                    if (remain == toLink)
                        remain = remainingRoomStack.Dequeue();
                    remain.ConnectedRooms.Add(toLink);
                    toLink.ConnectedRooms.Add(remain);
                    toLinkStack.Enqueue(remain);
                }
            }

            remainingRoomStack = new Queue<Room>(maze.Rooms);

            while (remainingRoomStack.Count != 0)
            {
                var room = remainingRoomStack.Dequeue();
                foreach (var otherRoom in remainingRoomStack.Where(otherRoom => !room.ConnectedRooms.Contains(otherRoom) && randomSeed.Next(0, 100) < randomLinkRate))
                {
                    room.ConnectedRooms.Add(otherRoom);
                    otherRoom.ConnectedRooms.Add(room);
                }
            }
            return maze;
        }
    }
}