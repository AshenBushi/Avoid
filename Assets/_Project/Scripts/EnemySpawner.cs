using System;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;

public class EnemySpawner : ObjectPool<Enemy>
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
    [Space(10f)] 
    [SerializeField] private ScoreCounter _scoreCounter;

    private float _timer = 0f;
    private bool _canSpawn = false;
    private float _spawnDelay;
    private float _moveDuration;

    private void Start()
    {
        _spawnDelay = _defaultDelay;
        _moveDuration = _defaultMoveDuration;
    }

    private void Update()
    {
        if (!_canSpawn) return;
        
        _timer += Time.deltaTime;

        if (_timer >= _spawnDelay)
        {
            SpawnEnemy();
            _timer = 0;
        }
    }

    private void SpawnEnemy()
    {
        var startPosition = new Vector3();
        var endPosition = new Vector3();
        var randomIndex = Random.Range(0, 4);

        switch (randomIndex)
        {
            case 0 :
                startPosition = _leftSide.GetRandomPoint();
                endPosition = _rightSide.GetRandomPoint();
                break;
            case 1 :
                startPosition = _rightSide.GetRandomPoint();
                endPosition = _leftSide.GetRandomPoint();
                break;
            case 2 :
                startPosition = _topSide.GetRandomPoint();
                endPosition = _bottomSide.GetRandomPoint();
                break;
            case 3 :
                startPosition = _bottomSide.GetRandomPoint();
                endPosition = _topSide.GetRandomPoint();
                break;
            default:
                break;
        }
        
        if (TryGetObject(out var enemy))
        {
            enemy.Init(startPosition, endPosition, 1, _moveDuration);
            enemy.OnMovingEnd += OnEnemyMovingEnd;
        }
        
        IncreaseDifficult();
    }

    private void OnEnemyMovingEnd(Enemy enemy)
    {
        _scoreCounter.AddScore();
        enemy.OnMovingEnd -= OnEnemyMovingEnd;
    }

    private void IncreaseDifficult()
    {
        var tempValue = _defaultMoveDuration - 0.4f * (_scoreCounter.Score / 100);
        
        _moveDuration = tempValue <= 0 ? 0.2f : tempValue;

        _spawnDelay = _defaultDelay - 0.9f * (float)(_scoreCounter.Score / 100f - Math.Truncate(_scoreCounter.Score / 100f));
    }
    
    public void StartGame()
    {
        _canSpawn = true;
    }
    
    public void EndGame()
    {
        _canSpawn = false;
    }
}

[Serializable]
public class SideRange
{
    [SerializeField] private Vector3 _firstPoint;
    [SerializeField] private Vector3 _lastPoint;

    public Vector3 GetRandomPoint()
    {
        var randomPoint = new Vector3(Random.Range(_firstPoint.x, _lastPoint.x),
            Random.Range(_firstPoint.y, _lastPoint.y), Random.Range(_firstPoint.z, _lastPoint.z));

        return randomPoint;
    }
}
