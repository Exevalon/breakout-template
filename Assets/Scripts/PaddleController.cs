using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Moves the paddle left/right from input (Move.x), keeps the ball on the paddle until launch,
/// and launches the ball at 45° on Jump (Space). Exposes ResetBallToPaddle() for lives/reset.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PaddleController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] Rigidbody2D ballRigidbody;
    [SerializeField] float launchSpeed = 10f;
    [Tooltip("Vertical offset from paddle center so ball sits on top. If 0, derived from colliders.")]
    [SerializeField] float ballOffsetY = 0.5f;

    Rigidbody2D _rb;
    BoxCollider2D _box;
    InputSystem_Actions _inputActions;
    bool _ballInPlay;
    float _cameraMinX, _cameraMaxX;
    float _paddleHalfWidth;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _box = GetComponent<BoxCollider2D>();
        _paddleHalfWidth = _box != null ? _box.size.x * 0.5f * transform.lossyScale.x : 0.5f;
    }

    void Start()
    {
        ComputeBounds();
        if (ballOffsetY == 0f && _box != null && ballRigidbody != null)
        {
            var ballCollider = ballRigidbody.GetComponent<CircleCollider2D>();
            float ballRadius = ballCollider != null ? ballCollider.radius * (ballRigidbody.transform.lossyScale.x) : 0.25f;
            ballOffsetY = _box.size.y * 0.5f * transform.lossyScale.y + ballRadius + 0.02f;
        }
    }

    void OnEnable()
    {
        _inputActions = new InputSystem_Actions();
        _inputActions.Player.Enable();
        _inputActions.Player.Jump.performed += OnJumpPerformed;
    }

    void OnDisable()
    {
        if (_inputActions != null)
        {
            _inputActions.Player.Jump.performed -= OnJumpPerformed;
            _inputActions.Player.Disable();
            _inputActions.Dispose();
            _inputActions = null;
        }
    }

    void OnDestroy()
    {
        if (_inputActions != null)
        {
            _inputActions.Player.Jump.performed -= OnJumpPerformed;
            _inputActions.Dispose();
        }
    }

    void FixedUpdate()
    {
        float moveX = _inputActions != null ? _inputActions.Player.Move.ReadValue<Vector2>().x : 0f;
        moveX = Mathf.Clamp(moveX, -1f, 1f);

        _rb.linearVelocity = new Vector2(moveX * moveSpeed, 0f);

        Vector2 pos = _rb.position;
        pos.x = Mathf.Clamp(pos.x, _cameraMinX + _paddleHalfWidth, _cameraMaxX - _paddleHalfWidth);
        _rb.position = pos;

        if (!_ballInPlay && ballRigidbody != null)
        {
            Vector2 ballPos = _rb.position + new Vector2(0f, ballOffsetY);
            ballRigidbody.position = ballPos;
            ballRigidbody.linearVelocity = Vector2.zero;
        }
    }

    void ComputeBounds()
    {
        var cam = Camera.main;
        if (cam == null) return;
        _cameraMinX = cam.ViewportToWorldPoint(new Vector3(0f, 0.5f, cam.nearClipPlane)).x;
        _cameraMaxX = cam.ViewportToWorldPoint(new Vector3(1f, 0.5f, cam.nearClipPlane)).x;
    }

    void OnJumpPerformed(InputAction.CallbackContext _)
    {
        if (_ballInPlay || ballRigidbody == null) return;

        float dir = Random.value > 0.5f ? 1f : -1f;
        Vector2 direction = new Vector2(dir, 1f).normalized;
        ballRigidbody.linearVelocity = direction * launchSpeed;
        _ballInPlay = true;
        if (SfxManager.Instance != null)
            SfxManager.Instance.PlayLaunchBall();
    }

    /// <summary>
    /// Called by the lives system when a life is lost and we should put the ball back on the paddle.
    /// </summary>
    public void ResetBallToPaddle()
    {
        _ballInPlay = false;
        if (ballRigidbody != null)
        {
            ballRigidbody.linearVelocity = Vector2.zero;
            ballRigidbody.position = _rb.position + new Vector2(0f, ballOffsetY);
        }
    }
}
