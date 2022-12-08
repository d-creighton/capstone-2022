using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Timer
{
    public static Coroutine DelayActionRetriggerable(MonoBehaviour monoBehavior,
    bool flag, float time, Coroutine coroutine)
    {
        if (coroutine != null)
        {
            monoBehavior.StopCoroutine(coroutine);
        }
        return monoBehavior.StartCoroutine(DelayActionRoutine(flag, time));
    }

    private static IEnumerator DelayActionRoutine(bool flag, float time)
    {
        yield return new WaitForSeconds(time);
        flag = true;
    }
}
