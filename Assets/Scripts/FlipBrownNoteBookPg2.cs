using System.Collections;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Within a range in seconds, call an event, continues for lifetime of object.
/// </summary>
public class FlipBrownNoteBookPg2 : MonoBehaviour
{
    [Tooltip("The minimum range")]
    public float minInterval = 0.0f;

    [Tooltip("The maximum range")]
    public float maxInterval = 1.0f;

    // Called once the wait is over
    public UnityEvent OnIntervalElapsed = new UnityEvent();

    public void StartEvent()
    {
        StartCoroutine(IntervalRoutine());
    }

    private IEnumerator IntervalRoutine()
    {
        float interval = Random.Range(minInterval, maxInterval);
        yield return new WaitForSeconds(interval);

        PlayEvent();
        //StartCoroutine(IntervalRoutine());
    }

    private void PlayEvent()
    {
        OnIntervalElapsed.Invoke();
    }
}