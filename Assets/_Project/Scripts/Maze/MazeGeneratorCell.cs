public class MazeGeneratorCell
{
    public int X;
    public int Y;
    public int DistanceFromStart;

    public bool IsWallLeft = true;
    public bool IsWallBottom = true;

    public bool IsVisited = false;
}
