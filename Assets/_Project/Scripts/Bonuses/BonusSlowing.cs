using UnityEngine;

public class BonusSlowing : Bonus
{
    [SerializeField] private float _time = 3f;

    protected override void UseBonus()
    {
        if (_player == null) return;
        if (_player.IsUsingBonus) return;

        SoundManager.Instance.PlaySound(Sound.Heal);

        SpawnersManager.Instance.SpawnerEnemy.SetStateEnemy(_player, StateEnemy.slowing, _time);
    }
}
