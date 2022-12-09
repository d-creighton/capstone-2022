using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Timer
{
    public static Coroutine DelayActionRetriggerable(State state,
    bool flag, float time, Coroutine coroutine)
    {
        if (coroutine != null)
        {
            state.StopCoroutine(coroutine);
        }
        flag = true;
        return state.StartCoroutine(DelayActionRoutine(flag, time));
    }

    private static IEnumerator DelayActionRoutine(bool flag, float time)
    {
        yield return new WaitForSeconds(time);
        //flag = true;
        Debug.Log(flag);
        //yield return flag;
    }
}
