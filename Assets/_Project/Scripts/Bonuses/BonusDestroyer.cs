using UnityEngine;

public class BonusDestroyer : Bonus
{
    [SerializeField] private float _time = 0f;

    protected override void UseBonus()
    {
        if (_player == null) return;
        if (_player.IsUsingBonus) return;

        SoundManager.Instance.PlaySound(Sound.Heal);

        SpawnersManager.Instance.SpawnerEnemy.SetStateEnemy(_player, StateEnemy.destroying, _time);
    }
}
