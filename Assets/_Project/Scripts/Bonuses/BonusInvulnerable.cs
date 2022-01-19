using System;
using System.Threading.Tasks;

public class BonusInvulnerable : Bonus
{
    protected override void UsingEffect()
    {
        if (_player == null) return;

        EffectTask();
    }

    private async void EffectTask()
    {
        _player.DisallowTakingDamage();

        await Task.Delay(TimeSpan.FromSeconds(3));

        _player.AllowTakingDamage();
    }
}
