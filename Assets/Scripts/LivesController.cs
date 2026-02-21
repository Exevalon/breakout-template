using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;

/// <summary>
/// Tracks lives, updates heart UI when the ball hits the death barrier, resets ball to paddle
/// when lives > 0, and shows game over + restart (R) when lives == 0.
/// </summary>
public class LivesController : MonoBehaviour
{
    [SerializeField] PaddleController paddleController;
    [SerializeField] Image[] heartImages = new Image[3];
    [SerializeField] Sprite heartFull;
    [SerializeField] Sprite heartEmpty;
    [SerializeField] GameObject gameOverPanel;

    int _lives = 3;
    bool _gameOver;

    void Start()
    {
        DeathBarrierController.OnBallEnteredDeathZone += OnBallEnteredDeathZone;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void OnDestroy()
    {
        DeathBarrierController.OnBallEnteredDeathZone -= OnBallEnteredDeathZone;
    }

    void Update()
    {
        if (!_gameOver) return;
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
            Restart();
    }

    void OnBallEnteredDeathZone()
    {
        if (_gameOver) return;

        if (SfxManager.Instance != null)
            SfxManager.Instance.PlayLoseLife();
        _lives--;
        if (_lives >= 0 && _lives < heartImages.Length && heartEmpty != null)
            heartImages[_lives].sprite = heartEmpty;

        if (_lives > 0)
        {
            if (paddleController != null)
                paddleController.ResetBallToPaddle();
        }
        else
        {
            _gameOver = true;
            if (paddleController != null)
                paddleController.enabled = false;
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
