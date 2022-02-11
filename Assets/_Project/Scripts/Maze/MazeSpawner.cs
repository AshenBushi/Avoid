using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    [SerializeField] private int _width = 4;
    [SerializeField] private int _heidth = 4;
    [SerializeField] private MazeCell _cellPrefab;
    [SerializeField] private Transform _parent;

    private Maze _maze;
    private Vector3 _cellSize = new Vector3(1, 1, 0);
    private List<MazeCell> _cells = new List<MazeCell>();

    public void Spawn()
    {
        transform.localPosition = Vector3.zero;
        _parent.localPosition = Vector3.zero;

        _cells = new List<MazeCell>();
        MazeGenerator generator = new MazeGenerator(_width, _heidth);
        _maze = generator.GenerateMaze();

        for (int x = 0; x < _maze.Cells.GetLength(0); x++)
        {
            for (int y = 0; y < _maze.Cells.GetLength(1); y++)
            {
                var cell = Instantiate(_cellPrefab, new Vector3(x * _cellSize.x, y * _cellSize.y, y * _cellSize.z), Quaternion.identity, transform);

                cell.WallLeft.SetActive(_maze.Cells[x, y].IsWallLeft);
                cell.WallBottom.SetActive(_maze.Cells[x, y].IsWallBottom);

                _cells.Add(cell);
            }
        }

        transform.localPosition = new Vector3(-_width / 2f, -_heidth / 2f, 0);
        _parent.localPosition = new Vector3(0.5f, 0.5f, 0);
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
