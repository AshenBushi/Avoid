using UnityEngine;

public class BonusDestroyerField : BonusField
{
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.TryGetComponent(out Enemy enemy)) return;

        enemy.Deactivation();
        Hide();
    }
}
