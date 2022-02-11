using UnityEngine;

public class MazeCell : MonoBehaviour
{
    [SerializeField] private GameObject _wallLeft;
    [SerializeField] private GameObject _wallBottom;

    public GameObject WallLeft => _wallLeft;
    public GameObject WallBottom => _wallBottom;
}
