using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{

    public Material matWhite;
    private Material matDefault;
    SpriteRenderer sr;

    // Update is called once per frame
    public void Hitter()
    {
        sr = GetComponent<SpriteRenderer>();

        matDefault = sr.material;
        StartCoroutine(Hit());
    }


    IEnumerator Hit()
    {

        yield return new WaitForSeconds(0.1f);
        sr.material = matWhite;

    }
}
