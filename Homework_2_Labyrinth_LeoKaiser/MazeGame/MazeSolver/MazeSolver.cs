using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Homework_2_Labyrinth_LeoKaiser.MazeGame.MazeSolver
{
    public static class MazeSolver
    {
        [return: MaybeNull]
        private static List<Room> RecursiveSolver(Maze maze, Room currentRoom, ICollection<Room> crossedRooms, IDictionary<Room, ICollection<Room>> calculatedRooms)
        {
            if (maze.End.Contains(currentRoom))
                return new List<Room>(crossedRooms) { currentRoom };
            if (calculatedRooms.TryGetValue(currentRoom, out var alreadyCalculated))
            {
                if (alreadyCalculated is null)
                    return null;
                var way = new List<Room>(crossedRooms);
                way.AddRange(alreadyCalculated);
                return way;
            }
            crossedRooms.Add(currentRoom);
            var crossingRooms = currentRoom.ConnectedRooms.Where(room => !crossedRooms.Contains(room)).ToList();
            List<Room> bestSearch = null;
            foreach (var linkedRoom in crossingRooms)
            {
                var search = RecursiveSolver(maze, linkedRoom, crossedRooms, calculatedRooms);
                if (search != null && (bestSearch is null || search.Count < bestSearch.Count))
                    bestSearch = search;
            }
            calculatedRooms.Add(currentRoom, bestSearch);
            crossedRooms.Remove(currentRoom);
            return bestSearch;
        }

        [return: MaybeNull]
        public static List<Room> SolveMaze(Maze maze)
        {
            return RecursiveSolver(maze, maze.Start, new List<Room>(), new Dictionary<Room, ICollection<Room>>());
        }
    }
}