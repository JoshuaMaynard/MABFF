using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] spawnList;
    public float health = 100;
    public float attack = 25;
    public GameObject deathEffect;
    public Material matWhite;
    protected Material matDefault;
    public SpriteRenderer sr;
    protected AudioSource mAudioSrc;
    public GameObject deathEffect2;
    public bool isBurning;
    float fadeOutTime = 1f;



    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        mAudioSrc = GetComponent<AudioSource>();
        matDefault = sr.material;

        

    }

    private void Update()
    {
        if (isBurning)
        {
            StartCoroutine(ResidualDamage());
        }
    }

    public virtual void TakeDamage (float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            
            Die();
            
        }

        
    }

    public virtual void Die()
    {
        Debug.Log("DieHarder");
        StartCoroutine(AudioPlay());
        FindObjectOfType<Free>().Stop(0.1f);
        Debug.Log("Die");
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            sr.material = matWhite;
            
        }
        if(health <= 0)
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            this.GetComponent<BoxCollider2D>().enabled = false;
            Die();

        }
        else
        {
            Invoke("ResetMaterial", .2f);
        }
    }

    void ResetMaterial()
    {
        sr.material = matDefault;

    }
    IEnumerator AudioPlay()
    {
        mAudioSrc.Play();
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            yield return null;
            
        }

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(deathEffect2, transform.position, Quaternion.identity);
        Instantiate(spawnList[0], transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }

    IEnumerator ResidualDamage()
    {

        

        Debug.Log("burning");
        TakeDamage(0.01f);



        yield return new WaitForSeconds(0.5f);
    }
}
