using System;
using System.Threading.Tasks;

public class BonusFreezing : Bonus
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
        _player.PlayEffectAnimation(TypeEffectAnimation.freezing);
        _player.DisallowMove();

        await Task.Delay(TimeSpan.FromSeconds(3));

        _player.AllowMove();
        _player.AllowUsingBonus();
    }
}
