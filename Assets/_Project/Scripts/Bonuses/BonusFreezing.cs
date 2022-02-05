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
        _player.PlayEffectAnimation(BonusType.Freezing);
        _player.DisallowMove();
        
        SoundManager.Instance.PlaySound(Sound.TakeDamage);
        
        UIManager.Instance.GameScreen.BonusDisplay.ShowBonusIcon(BonusType.Freezing);

        await Task.Delay(TimeSpan.FromSeconds(3));

        _player.StopEffectAnimation(BonusType.Freezing);
        _player.AllowMove();
        _player.AllowUsingBonus();
        
        UIManager.Instance.GameScreen.BonusDisplay.Clear();
    }
}
