using UnityEngine;

/// <summary>
/// Attach to the Ball. Plays Snd1 when the ball hits a Wall, Powerup when it hits the Paddle.
/// SfxManager varies pitch each time for a more natural sound.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class BallBounceSound : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (SfxManager.Instance == null) return;

        if (collision.gameObject.CompareTag("Paddle"))
            SfxManager.Instance.PlayPaddleBounce();
        else if (collision.gameObject.CompareTag("Wall"))
            SfxManager.Instance.PlayWallBounce();
    }
}
