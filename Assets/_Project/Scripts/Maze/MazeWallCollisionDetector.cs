using UnityEngine;

public class MazeWallCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.collider.TryGetComponent(out Player player)) return;

        player.TakeDamage(1);
    }
}
