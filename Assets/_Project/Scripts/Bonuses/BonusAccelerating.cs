using UnityEngine;

public class BonusAccelerating : Bonus
{
    [SerializeField] private BonusAcceleratingField _acceleratingFieldTemplate;

    protected override void UseBonus()
    {
        if (_player == null) return;
        if (_player.IsUsingBonus) return;

        _player.DisallowUsingBonus();

        var field = Instantiate(_acceleratingFieldTemplate, _player.transform.parent);
        field.Init(_player);
        field.Show();
        field.SetTimeSeconds(3f);
    }
}
