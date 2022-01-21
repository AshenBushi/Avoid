using UnityEngine;

public class BonusDestroyerField : BonusField
{
    private Player _player;

    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Enemy enemy)) return;

        enemy.Die();
        _player.AllowUsingBonus();
        Hide();
    }

    public void Init(Player player)
    {
        _player = player;
    }
}
