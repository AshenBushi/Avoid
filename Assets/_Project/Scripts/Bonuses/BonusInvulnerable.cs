using System;
using System.Threading.Tasks;
using UnityEngine;

public class BonusInvulnerable : Bonus
{
    [SerializeField] private int _time = 3;

    protected override void UseBonus()
    {
        if (_player == null) return;

        if (_player.IsUsingBonus) return;
        _player.DisallowUsingBonus();

        EffectTask();
    }

    private async void EffectTask()
    {
        _player.PlayEffectAnimation(TypeEffect.invulnerable);
        _player.DisallowTakingDamage();

        await Task.Delay(TimeSpan.FromSeconds(_time));

        _player.StopEffectAnimation(TypeEffect.invulnerable);
        _player.AllowUsingBonus();
        _player.AllowTakingDamage();
    }
}
