using UnityEngine;

public class BonusSlowing : Bonus
{
    [SerializeField] private BonusSlowingField _slowingFieldTemplate;

    protected override void UseBonus()
    {
        if (_player == null) return;
        if (_player.IsUsingBonus) return;

        var field = Instantiate(_slowingFieldTemplate, _player.transform.parent);
        field.Show();
        field.SetTimeSeconds(3f);
    }
}
