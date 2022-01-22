using System;
using System.Threading.Tasks;
using UnityEngine;

public class BonusInvulnerable : Bonus
{
    [SerializeField] private int _timeSeconds = 3;
    [SerializeField] private bool _isDontEnemyBonus;

    protected override void UseBonus()
    {
        if (_player == null) return;
         
        if (!_isDontEnemyBonus)
        {
            EffectTask();
        }
        else
        {
            if (_player.IsUsingBonus) return;
            _player.DisallowUsingBonus();

            EffectTask();
        }
    }

    private async void EffectTask()
    {
        _player.PlayEffectAnimation(TypeEffect.invulnerable);
        _player.DisallowTakingDamage();

        await Task.Delay(TimeSpan.FromSeconds(_timeSeconds));

        _player.StopEffectAnimation(TypeEffect.invulnerable);
        _player.AllowTakingDamage();

        if (_isDontEnemyBonus)
            _player.AllowUsingBonus();
    }
}
