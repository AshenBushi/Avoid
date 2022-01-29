using UnityEngine;

public class BonusAccelerating : Bonus
{
    [SerializeField] private float _time = 3f;

    protected override void UseBonus()
    {
        if (_player == null) return;
        if (_player.IsUsingBonus) return;

        _player.DisallowUsingBonus();

        SpawnersManager.Instance.SpawnerEnemy.SetStateEnemy(_player, StateEnemy.acceleration, _time);
    }
}
