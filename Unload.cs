using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unload : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public int scene;
    bool unloaded;

    void OnTriggerEnter2D()
    {
        if (!unloaded)
        {
            StartCoroutine(NextScene());


        }


    }

    IEnumerator NextScene()
    {

        yield return new WaitForSeconds(transitionTime);

        AnyManager.anyManager.UnloadScene(scene);

        unloaded = true;


    }

}
