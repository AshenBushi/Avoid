using UnityEngine;

public class BonusDestroyer : Bonus
{
    [SerializeField] private BonusDestroyerField _destroyerFieldTemplate;

    protected override void UseBonus()
    {
        if (_player == null) return;
        if (_player.IsUsingBonus) return;

        _player.DisallowUsingBonus();

        var field = Instantiate(_destroyerFieldTemplate, _player.transform.parent);
        field.Init(_player);
        field.Show();
    }
}
