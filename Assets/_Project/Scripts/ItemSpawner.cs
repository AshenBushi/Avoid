using UnityEngine;

public class ItemSpawner : ObjectPool<Shot>, ISpawner
{
    [Space(20f)]
    [SerializeField] private SideRange _leftSide;
    [SerializeField] private SideRange _rightSide;
    [SerializeField] private SideRange _topSide;
    [SerializeField] private SideRange _bottomSide;
    [Space(10f)]
    [Header("Spawn Parameters")]
    [SerializeField] private float _defaultDelay;
    [SerializeField] private float _defaultMoveDuration;

    private float _timer = 0f;
    private float _spawnDelay;
    private float _moveDuration;
    private bool _canSpawn;

    public bool IsSpawned { get; private set; }

    private void Start()
    {
        _spawnDelay = _defaultDelay;
        _moveDuration = _defaultMoveDuration;
    }

    private void FixedUpdate()
    {
        if (!_canSpawn) return;

        _timer += Time.fixedDeltaTime;

        if (_timer >= _spawnDelay)
        {
            Spawn();
            _timer = 0;
        }
    }

    public void GetRandomPositions(out Vector3 startPosition, out Vector3 endPosition)
    {
        var randomIndex = Random.Range(0, 4);

        switch (randomIndex)
        {
            case 0:
                startPosition = _leftSide.GetRandomPoint();
                endPosition = _rightSide.GetRandomPoint();
                break;
            case 1:
                startPosition = _rightSide.GetRandomPoint();
                endPosition = _leftSide.GetRandomPoint();
                break;
            case 2:
                startPosition = _topSide.GetRandomPoint();
                endPosition = _bottomSide.GetRandomPoint();
                break;
            case 3:
                startPosition = _bottomSide.GetRandomPoint();
                endPosition = _topSide.GetRandomPoint();
                break;
            default:
                startPosition = _leftSide.GetRandomPoint();
                endPosition = _rightSide.GetRandomPoint();
                break;
        }
    }

    public void Spawn()
    {
        var random = Random.Range(1, 101);
        if (random <= 50) return;

        GetRandomPositions(out var startPosition, out var endPosition);

        if (TryGetObject(out var item))
        {
            item.Init(startPosition, endPosition, _moveDuration);
        }
    }

    public void StartSpawning()
    {
        _canSpawn = true;
    }

    public void EndSpawning()
    {
        _canSpawn = false;
    }
}
