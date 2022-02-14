using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Free : MonoBehaviour
{
    bool waiting;

    // Update is called once per frame
    public void Stop(float duration)
    {
        if (waiting)
            return;
        Time.timeScale = 0.0f;
        StartCoroutine(Freeze(duration));
    }


    IEnumerator Freeze(float duration)
    {
        waiting = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        waiting = false;
    }

}
