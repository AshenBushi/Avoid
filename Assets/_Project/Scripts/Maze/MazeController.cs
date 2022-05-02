using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

public class MazeController : MonoBehaviour
{
    [SerializeField] private float _mazeStartPoint = 8f;
    [SerializeField] private float _mazeEndPoint = -1f;
    [SerializeField] private float _durationMovingMaze = 10f;
    [SerializeField] private BorderController _gameBorderController;
    [SerializeField] private Color _gameBorderColor = Color.red;

    private MazeSpawnerCells _mazeSpawner;
    private Tween _tween;
    private bool _isCreated = false;

    public static UnityEvent MazeCompleteEvent = new UnityEvent();
    public static UnityEvent MazeDestroyEvent = new UnityEvent();

    private void Awake()
    {
        _mazeSpawner = GetComponentInChildren<MazeSpawnerCells>();
        ScoreCounter.StartNextWaveEvent.AddListener(Spawn);
    }

    public void Spawn()
    {
        if (_isCreated || UIManager.Instance.GameOverScreen.IsGameOver) return;

        _isCreated = true;
        MazeDestroyEvent.AddListener(Clear);

        transform.localPosition = Vector3.zero;

        _gameBorderController.SetDangerous(_gameBorderColor);

        _mazeSpawner.SpawnCells();

        transform.position = new Vector3(transform.position.x, _mazeStartPoint, transform.position.z);
        _tween = transform.DOMoveY(_mazeEndPoint, _durationMovingMaze).SetLink(gameObject).SetEase(Ease.Linear);

        _tween.OnComplete(() =>
        {
            Clear();
            MazeCompleteEvent?.Invoke();
        });
    }

    private void Clear()
    {
        _tween.OnKill(() =>
        {
            _gameBorderController.SetSafe();
            MazeDestroyEvent.RemoveListener(Clear);
            _mazeSpawner.Clear();
            _isCreated = false;
            //transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        });

        _tween.Kill();
    }
}
