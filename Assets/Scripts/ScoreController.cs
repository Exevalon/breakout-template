using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
  [SerializeField] private BlockCount counter;

  public UnityEvent onCounterReachingZero;

  private void Update()
  {
    if(counter.blockCount == 0)
      ActivateWinPanel();
  }

  private void ActivateWinPanel()
  {
    onCounterReachingZero?.Invoke();
  }
}
