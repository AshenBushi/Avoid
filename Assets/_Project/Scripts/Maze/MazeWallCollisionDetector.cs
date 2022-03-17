using UnityEngine;

public class MazeWallCollisionDetector : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.TryGetComponent(out Player player)) return;

        player.TakeDamage(1);
    }
}
