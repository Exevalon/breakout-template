using System;
using UnityEngine;

/// <summary>
/// Attach to the DeathBarrier GameObject. Ensure it has a Collider2D set as Trigger.
/// When the ball enters the trigger, raises OnBallEnteredDeathZone for the lives system.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class DeathBarrierController : MonoBehaviour
{
    public static event Action OnBallEnteredDeathZone;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Ball")) return;
        OnBallEnteredDeathZone?.Invoke();
    }
}
