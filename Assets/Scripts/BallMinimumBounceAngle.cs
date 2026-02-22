using UnityEngine;

/// <summary>
/// Attach to the Ball. Ensures the ball never travels at a nearly horizontal angle after
/// bouncing off the paddle, walls, or blocks — re-clamps velocity to a minimum angle from horizontal.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BallMinimumBounceAngle : MonoBehaviour
{
    [Tooltip("Minimum angle in degrees from horizontal (0 = flat). e.g. 15 means the ball is never flatter than 15°.")]
    [SerializeField] float minAngleFromHorizontal = 15f;
    [Tooltip("Only correct when speed is above this (avoids affecting ball at rest on paddle).")]
    [SerializeField] float minSpeed = 0.5f;

    Rigidbody2D _rb;
    float _minAngleRad;
    float _minVerticalRatio;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        UpdateAngleCache();
    }

    void OnValidate()
    {
        UpdateAngleCache();
    }

    void UpdateAngleCache()
    {
        float deg = Mathf.Clamp(minAngleFromHorizontal, 1f, 89f);
        _minAngleRad = deg * Mathf.Deg2Rad;
        _minVerticalRatio = Mathf.Sin(_minAngleRad);
    }

    void FixedUpdate()
    {
        Vector2 v = _rb.linearVelocity;
        float speed = v.magnitude;
        if (speed < minSpeed) return;

        float absVy = Mathf.Abs(v.y);
        float minVertical = speed * _minVerticalRatio;
        if (absVy >= minVertical) return;

        // Rebuild velocity with same speed and direction but at least min angle from horizontal
        float vx = v.x >= 0 ? speed * Mathf.Cos(_minAngleRad) : -speed * Mathf.Cos(_minAngleRad);
        float vy = v.y >= 0 ? speed * _minVerticalRatio : -speed * _minVerticalRatio;
        _rb.linearVelocity = new Vector2(vx, vy);
    }
}
