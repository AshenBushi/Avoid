using System;
using UnityEngine;

public enum StateEnemy
{
    none,
    slowing,
    acceleration,
    destroying
}

public class SpawnerEnemy : Spawner, IStateEnemy
{
    [SerializeField] private ScoreCounter _scoreCounter;

    private Player _player;
    private StateEnemy _state;
    private float _time;
    private bool _isStateTimerOn;

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

        if (TryGetObject(out var enemy))
        {
            enemy.Init(startPosition, endPosition, _moveDuration);
            enemy.SetDamageDone(1);
            enemy.OnMovingEnd += OnEnemyMovingEnd;

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

    private void OnEnemyMovingEnd(Item enemy)
    {
        _scoreCounter.AddScore();
        enemy.OnMovingEnd -= OnEnemyMovingEnd;
    }

    private void IncreaseDifficult()
    {
        var tempValue = _defaultMoveDuration - 0.4f * (_scoreCounter.Score / 100);

        _moveDuration = tempValue <= 0 ? 0.2f : tempValue;

        _spawnDelay = _defaultDelay - 0.8f * (float)(_scoreCounter.Score / 100f - Math.Truncate(_scoreCounter.Score / 100f));
    }
}