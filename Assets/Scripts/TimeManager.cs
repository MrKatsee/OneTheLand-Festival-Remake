using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TimeManager
{
    public static IEnumerator WaitForRealTime(float delay)
    {
        while (true)
        {
            float pauseEndTime = Time.realtimeSinceStartup + delay;
            while (Time.realtimeSinceStartup < pauseEndTime)
            {
                yield return 0;
            }
            break;
        }
    }
    // use :  yield return StartCoroutine(TimeManager.WaitForRealTime(1));

}