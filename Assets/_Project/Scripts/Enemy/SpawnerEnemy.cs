using System;
using System.Collections.Generic;
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
    private int _newItemIndexCounter = 0;
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
            enemy.OnEndedMoving += OnEndedMovingEnemy;

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

            _pool[i].OnEndedMoving -= OnEndedMovingEnemy;
            _pool[i].OnEndedMoving += OnEndingMovingEvemyWithoutScore;

            _pool[i].Deactivation();
        }
    }

    protected override void OnNextWave()
    {
        var itemNextWave = _enemyTemplatesByCurrentWave[_scoreCounter.WaveCounter - 2];

        if (itemNextWave == null || _pool.Contains(itemNextWave))
            return;

        var newItem = Instantiate(itemNextWave, _container);
        newItem.gameObject.SetActive(false);

        _pool.Add(newItem);

        var tempItem = _pool[_newItemIndexCounter];
        _pool[_newItemIndexCounter] = newItem;
        _pool[_pool.Count - 1] = tempItem;

        _newItemIndexCounter++;
    }

    private void OnEndedMovingEnemy(Item enemy)
    {
        _scoreCounter.AddScore();
        enemy.OnEndedMoving -= OnEndedMovingEnemy;
    }

    private void OnEndingMovingEvemyWithoutScore(Item enemy)
    {
        enemy.OnEndedMoving -= OnEndedMovingEnemy;
    }
}