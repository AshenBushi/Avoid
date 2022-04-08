using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator
{
    public int _width = 4;
    public int _height = 4;

    public MazeGenerator(int width, int height)
    {
        _width = width;
        _height = height;
    }

    public Maze GenerateMaze()
    {
        var cells = new MazeGeneratorCell[_width, _height];

        for (var x = 0; x < cells.GetLength(0); x++)
        {
            for (var y = 0; y < cells.GetLength(1); y++)
            {
                cells[x, y] = new MazeGeneratorCell { X = x, Y = y };
            }
        }

        for (var x = 0; x < cells.GetLength(0); x++)
        {
            cells[x, _height - 1].IsWallLeft = false;
        }

        for (var y = 0; y < cells.GetLength(1); y++)
        {
            cells[_width - 1, y].IsWallBottom = false;
        }

        cells[Random.Range(1, _width - 1), _height - 1].IsWallBottom = false;
        cells[Random.Range(1, _width - 1), 0].IsWallBottom = false;

        for (int i = 0; i < cells.GetLength(1); i++)
        {
            cells[0, i].IsWallLeft = false;
            cells[_width - 1, i].IsWallLeft = false;
        }

        RemoveWallsWithBacktracker(cells);

        Maze maze = new Maze();

        maze.Cells = cells;

        return maze;
    }

    private void RemoveWallsWithBacktracker(MazeGeneratorCell[,] maze)
    {
        var current = maze[0, 0];
        current.IsVisited = true;
        current.DistanceFromStart = 0;

        Stack<MazeGeneratorCell> stack = new Stack<MazeGeneratorCell>();

        do
        {
            var unvisitedNeighbours = new List<MazeGeneratorCell>();

            var x = current.X;
            var y = current.Y;

            if (x > 0 && !maze[x - 1, y].IsVisited)
                unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].IsVisited)
                unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < _width - 2 && !maze[x + 1, y].IsVisited)
                unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < _height - 2 && !maze[x, y + 1].IsVisited)
                unvisitedNeighbours.Add(maze[x, y + 1]);


            if (unvisitedNeighbours.Count > 0)
            {
                var chosen = unvisitedNeighbours[Random.Range(0, unvisitedNeighbours.Count)];

                RemoveWall(current, chosen);

                chosen.IsVisited = true;
                stack.Push(chosen);
                chosen.DistanceFromStart = stack.Count - current.DistanceFromStart - 1;
                current = chosen;
            }
            else
            {
                current = stack.Pop();
            }

        } while (stack.Count > 0);
    }


    private void RemoveWall(MazeGeneratorCell a, MazeGeneratorCell b)
    {
        if (a.X == b.X)
        {
            if (a.Y > b.Y)
                a.IsWallBottom = false;
            else b.IsWallBottom = false;
        }
        else
        {
            if (a.X > b.X)
                a.IsWallLeft = false;
            else b.IsWallLeft = false;
        }
    }

    private MazeGeneratorCell PlaceMazeExit(MazeGeneratorCell[,] maze, bool isFinish)
    {
        MazeGeneratorCell mazeExit = maze[0, 0];

        if (!isFinish) return mazeExit;

        for (var x = 0; x < maze.GetLength(0); x++)
        {
            if (maze[x, _height - 2].DistanceFromStart > mazeExit.DistanceFromStart) mazeExit = maze[x, _height - 2];
            if (maze[x, 0].DistanceFromStart > mazeExit.DistanceFromStart) mazeExit = maze[x, 0];
        }

        for (var y = 0; y < maze.GetLength(1); y++)
        {
            if (maze[_width - 1, y].DistanceFromStart > mazeExit.DistanceFromStart) mazeExit = maze[_width - 1, y];
            if (maze[0, y].DistanceFromStart > mazeExit.DistanceFromStart) mazeExit = maze[0, y];
        }


        if (mazeExit.X == 0) mazeExit.IsWallLeft = false;
        else if (mazeExit.Y == 0) mazeExit.IsWallBottom = false;
        else if (mazeExit.X == _width - 2) maze[mazeExit.X + 1, mazeExit.Y].IsWallLeft = false;
        else if (mazeExit.Y == _height - 2) maze[mazeExit.X, mazeExit.Y + 1].IsWallBottom = false;

        return mazeExit;
    }
}
