using System.Collections.Generic;

public class Maze
{
    public MazeGeneratorCell[,] Cells;

    public MazeGeneratorCell StartCell;
    public MazeGeneratorCell FinishCell;

    public List<MazeGeneratorCell> _cellsDebug = new List<MazeGeneratorCell>();
}
