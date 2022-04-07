using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool<Item>, ISpawner
{
    [SerializeField] protected List<Item> _itemTemplates = new List<Item>();
    [Space(20f)]
    [SerializeField] protected SideRange _leftSide;
    [SerializeField] protected SideRange _rightSide;
    [SerializeField] protected SideRange _topSide;
    [SerializeField] protected SideRange _bottomSide;
    [Space(10f)]
    [Header("Spawn Parameters")]
    [SerializeField] protected float _defaultDelay;
    [SerializeField] protected float _defaultMoveDuration;

    protected float _timer = 0f;
    protected float _spawnDelay;
    protected float _moveDuration;
    protected bool _canSpawn = false;

    protected virtual void Start()
    {
        _spawnDelay = _defaultDelay;
        _moveDuration = _defaultMoveDuration;

        ScoreCounter.OnMazeActivationEvent.AddListener(EndSpawning);
        MazeController.MazeCompleteEvent.AddListener(StartSpawning);
    }

    protected virtual void FixedUpdate()
    {
        if (!_canSpawn) return;

        _timer += Time.fixedDeltaTime;

        if (_timer >= _spawnDelay)
        {
            Spawn();
            _timer = 0;
        }
    }

    protected override void InitPool()
    {
        for (var i = 0; i < _poolCount; i++)
        {
            for (int j = 0; j < _itemTemplates.Count; j++)
            {
                _pool.Add(Instantiate(_itemTemplates[j], _container));
                _pool[i].gameObject.SetActive(false);
            }
        }
    }

    public virtual void GetRandomPositions(out Vector3 startPosition, out Vector3 endPosition)
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

    public virtual void Spawn()
    {
        GetRandomPositions(out var startPosition, out var endPosition);

        List<Item> listDisableItems = new List<Item>();

        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i].gameObject.activeSelf) continue;

            listDisableItems.Add(_pool[i]);
        }

        listDisableItems[Random.Range(0, listDisableItems.Count)].Init(startPosition, endPosition, _moveDuration);
    }

    public virtual void Spawn(Item item, Transform transform)
    {
        GetRandomPositions(out var startPosition, out var endPosition);

        for (int i = 0; i < _pool.Count; i++)
        {
            if (_pool[i] == item)
            {
                _pool[i].Init(startPosition, endPosition, _moveDuration);
                _pool[i].transform.position = transform.position;
                break;
            }
        }
    }

    public virtual void StartSpawning()
    {
        _canSpawn = true;
    }

    public virtual void EndSpawning()
    {
        _canSpawn = false;
    }
}
