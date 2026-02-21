using UnityEngine;

/// <summary>
/// Single AudioSource that plays one-shot SFX. Assign clips in the Inspector.
/// Place on a persistent GameObject (e.g. GameManager) so it survives scene load if needed.
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class SfxManager : MonoBehaviour
{
    public static SfxManager Instance { get; private set; }

    [Header("Gameplay sounds")]
    [Tooltip("Ball hits a block (e.g. ChosenSelection_v2)")]
    [SerializeField] AudioClip blockHit;
    [Tooltip("Player loses a life (e.g. snd_explosion_1)")]
    [SerializeField] AudioClip loseLife;
    [Tooltip("Player launches the ball (e.g. snd_shot_sharp)")]
    [SerializeField] AudioClip launchBall;
    [Tooltip("Ball bounces off walls (e.g. Snd1)")]
    [SerializeField] AudioClip wallBounce;
    [Tooltip("Ball bounces off paddle (e.g. Powerup)")]
    [SerializeField] AudioClip paddleBounce;

    [Header("Bounce pitch variation")]
    [SerializeField] float pitchMin = 0.92f;
    [SerializeField] float pitchMax = 1.08f;

    AudioSource _source;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        _source = GetComponent<AudioSource>();
        if (_source != null)
            _source.playOnAwake = false;
    }

    void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }

    public void PlayBlockHit()
    {
        if (blockHit != null && _source != null)
            _source.PlayOneShot(blockHit);
    }

    public void PlayLoseLife()
    {
        if (loseLife != null && _source != null)
            _source.PlayOneShot(loseLife);
    }

    public void PlayLaunchBall()
    {
        if (launchBall != null && _source != null)
            _source.PlayOneShot(launchBall);
    }

    public void PlayWallBounce()
    {
        PlayWithRandomPitch(wallBounce);
    }

    public void PlayPaddleBounce()
    {
        PlayWithRandomPitch(paddleBounce);
    }

    void PlayWithRandomPitch(AudioClip clip)
    {
        if (clip == null || _source == null) return;
        float prevPitch = _source.pitch;
        _source.pitch = Random.Range(pitchMin, pitchMax);
        _source.PlayOneShot(clip);
        _source.pitch = prevPitch;
    }
}
