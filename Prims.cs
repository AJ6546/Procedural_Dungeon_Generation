using System.Collections.Generic;
using UnityEngine;

public class Prims : Maze
{
    public override void Generate()
    {
        int x = 2;
        int z = 2;

        map[x, z] = 0;

        List<MapLocation> walls = new List<MapLocation>();
        AddWalls(x, z, walls);

        int countLoops = 0;

        while (walls.Count > 0 && countLoops < 5000)
        {
            int rWall = Random.Range(0, walls.Count);
            x = walls[rWall].x;
            z = walls[rWall].z;

            walls.RemoveAt(rWall);

            if (CountSquareNeighbours(x, z) == 1)
            {
                map[x, z] = 0;
                AddWalls(x, z, walls);
            }

            countLoops++;
        }

    }

    private static void AddWalls(int x, int z, List<MapLocation> walls)
    {
        walls.Add(new MapLocation(x + 1, z));
        walls.Add(new MapLocation(x - 1, z));
        walls.Add(new MapLocation(x, z + 1));
        walls.Add(new MapLocation(x, z - 1));
    }
}
