using System;
using System.Threading.Tasks;

public class BonusInvulnerable : Bonus
{
    protected override void UseBonus()
    {
        if (_player == null) return;
        if (_player.IsUsingBonus) return;

        _player.DisallowUsingBonus();
        EffectTask();
    }

    private async void EffectTask()
    {
        _player.PlayEffectAnimation(TypeEffectAnimation.invulnerable);
        _player.DisallowTakingDamage();

        await Task.Delay(TimeSpan.FromSeconds(3));

        _player.AllowTakingDamage();
        _player.AllowUsingBonus();
    }
}
