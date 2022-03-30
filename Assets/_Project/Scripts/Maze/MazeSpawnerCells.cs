using System.Collections.Generic;
using UnityEngine;

public class MazeSpawnerCells : MonoBehaviour
{
    [SerializeField] private MazeCell _cellPrefab;
    [SerializeField] private Transform _parent;
    private int _width = 4;
    private int _heidth = 8;

    private Maze _maze;
    private Vector3 _cellSize = new Vector3(1.8f, 1, 0f);
    private List<MazeCell> _cells = new List<MazeCell>();

    public void SpawnCells()
    {
        transform.localPosition = Vector3.zero;

        _cells = new List<MazeCell>();
        MazeGenerator generator = new MazeGenerator(_width, _heidth);
        _maze = generator.GenerateMaze();

        for (int x = 0; x < _maze.Cells.GetLength(0); x++)
        {
            for (int y = 0; y < _maze.Cells.GetLength(1); y++)
            {
                var cell = Instantiate(_cellPrefab, new Vector3(x * _cellSize.x, y * _cellSize.y, 0f), Quaternion.identity, transform);
                cell.transform.localPosition = new Vector3(cell.transform.localPosition.x, cell.transform.localPosition.y, 0f);
                cell.WallLeft.SetActive(_maze.Cells[x, y].IsWallLeft);
                cell.WallBottom.SetActive(_maze.Cells[x, y].IsWallBottom);

                _cells.Add(cell);
            }
        }

        transform.position = new Vector3(-_width / (_cellSize.x * 0.8f), -_heidth / (_cellSize.y * 1.2f), 0f);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);
    }

    public void Clear()
    {
        for (int i = 0; i < _cells.Count; i++)
        {
            Destroy(_cells[i].gameObject);
        }

        _cells = null;
        _maze = null;
    }
}
