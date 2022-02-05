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
        _player.PlayEffectAnimation(BonusType.Invulnerable);
        _player.DisallowTakingDamage();
        
        SoundManager.Instance.PlaySound(Sound.Heal);
        
        UIManager.Instance.GameScreen.BonusDisplay.ShowBonusIcon(BonusType.Invulnerable);

        await Task.Delay(TimeSpan.FromSeconds(_time));

        _player.StopEffectAnimation(BonusType.Invulnerable);
        _player.AllowUsingBonus();
        _player.AllowTakingDamage();
        
        UIManager.Instance.GameScreen.BonusDisplay.Clear();
    }
}
