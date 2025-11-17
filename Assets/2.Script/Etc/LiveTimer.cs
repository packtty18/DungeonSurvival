using UnityEngine;
using System.Collections;

public class LiveTimer : MonoBehaviour
{
    [Header("Lifetime Settings")]
    public float liveTime = 1f;
    public bool AutoStart = false;
    private Coroutine timerCoroutine;

    private void Start()
    {
        if(AutoStart)
        {
            TimerStart();
        }
    }
    public void TimerStart()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }

        timerCoroutine = StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(liveTime);

        if (TryGetComponent<IPoolable>(out IPoolable poolable))
        {
            poolable.OnDespawn();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TimerStop()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }
}
