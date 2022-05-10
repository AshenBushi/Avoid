using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum StateEnemy
{
    none,
    slowing,
    acceleration,
    destroying
}

public class SpawnerEnemy : Spawner, ISpawnerEnemyState
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private List<Item> _enemyTemplatesByCurrentWave;

    private Player _player;
    private StateEnemy _state;
    private float _time;
    private bool _isStateTimerOn;

    private const int PERCENT_LIGHTNING_MOVE = 19;
    private const int PERCENT_DEGREES_MOVE = 29;
    private const int PERCENT_SPIRAL_MOVE = 39;

    protected override void FixedUpdate()
    {
        if (_isStateTimerOn)
        {
            if (_time <= 0)
            {
                _state = StateEnemy.none;
                _isStateTimerOn = false;
                _player.AllowUsingBonus();
            }
            else
                _time -= Time.fixedDeltaTime;
        }

        base.FixedUpdate();
    }

    public override void Spawn()
    {
        GetRandomPositions(out var startPosition, out var endPosition);

        Item enemy = null;
        Item enemyNew = null;
        var random = UnityEngine.Random.Range(0, 101);

        if (random < PERCENT_LIGHTNING_MOVE)
            enemyNew = GetEnemyByTypeFromPool(startPosition, endPosition, EnemyMovementType.Lightning);
        else if (random > PERCENT_LIGHTNING_MOVE && random <= PERCENT_DEGREES_MOVE)
            enemyNew = GetEnemyByTypeFromPool(startPosition, endPosition, EnemyMovementType.Degrees90);
        else if (random > PERCENT_DEGREES_MOVE && random <= PERCENT_SPIRAL_MOVE)
            enemyNew = GetEnemyByTypeFromPool(startPosition, endPosition, EnemyMovementType.Spiral);

        if (enemyNew != null)
            enemy = enemyNew;
        else
        {
            do
            {
                TryGetObject(out var enemyDefault);
                enemy = enemyDefault;
            }
            while (enemy == null);
        }

        enemy.Init(startPosition, endPosition, _moveDuration);
        enemy.SetDamageDone(1);
        enemy.OnEndedMoving.AddListener(OnEndedMovingEnemy);

        if (_isStateTimerOn)
        {
            switch (_state)
            {
                case StateEnemy.slowing:
                    enemy.SetSpeedDown();
                    break;
                case StateEnemy.acceleration:
                    enemy.SetSpeedUp();
                    break;
            }
        }

        IncreaseDifficult();
    }

    public void SetStateEnemy(Player player, StateEnemy state, float time)
    {
        _player = player;
        _state = state;
        _time = time;

        if (_state == StateEnemy.destroying)
        {
            for (int i = 0; i < _pool.Count; i++)
            {
                if (!_pool[i].gameObject.activeSelf) continue;

                _pool[i].Deactivation();
            }

            _player.AllowUsingBonus();
            return;
        }

        _isStateTimerOn = true;
    }

    private Item GetEnemyByTypeFromPool(Vector3 startPos, Vector3 endPos, EnemyMovementType type)
    {
        Item curObj = null;

        foreach (var currentObject in _pool.Where(currentObject =>
                        currentObject.GetComponent<Enemy>().MovementType == type &&
                        currentObject.gameObject.activeSelf == false))
        {
            curObj = currentObject;
            return curObj;
        }

        return curObj;
    }

    private void IncreaseDifficult()
    {
        var tempValue = _defaultMoveDuration - 0.4f * (_scoreCounter.Score / 100);

        _moveDuration = tempValue <= 0 ? 0.2f : tempValue;

        _spawnDelay = _defaultDelay - 0.8f * (float)(_scoreCounter.Score / 100f - Math.Truncate(_scoreCounter.Score / 100f));
    }

    protected override void DeactivationAllObject()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].gameObject.activeSelf) continue;

            _pool[i].OnEndedMoving.RemoveListener(OnEndedMovingEnemy);
            _pool[i].OnEndedMoving.AddListener(OnEndingMovingEvemyWithoutScore);

            _pool[i].Deactivation();
        }
    }

    protected override void OnNextWave()
    {
        if (_enemyTemplatesByCurrentWave.Count == 0) return;

        var itemNextWave = _enemyTemplatesByCurrentWave[0];

        if (itemNextWave == null || _pool.Contains(itemNextWave))
            return;

        var newItem = Instantiate(itemNextWave, _container);
        newItem.gameObject.SetActive(false);

        _pool.Insert(2, newItem);
        _enemyTemplatesByCurrentWave.RemoveAt(0);
    }

    private void OnEndedMovingEnemy(Item enemy)
    {
        _scoreCounter.AddScore();
        enemy.OnEndedMoving.RemoveListener(OnEndedMovingEnemy);
    }

    private void OnEndingMovingEvemyWithoutScore(Item enemy)
    {
        enemy.OnEndedMoving.RemoveListener(OnEndingMovingEvemyWithoutScore);
    }
}