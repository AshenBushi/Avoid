using UnityEngine;

public class BonusDestroyerField : MonoBehaviour
{
    private Player _player;

    private void OnTriggerEnter2D(Collider2D collision)
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

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        Destroy(gameObject);
    }
}
