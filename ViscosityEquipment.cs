using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViscosityEquipment : MonoBehaviour
{
    public GameObject currentTeleporter;
    private Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer sr;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            //anim
            if (currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;
               // anim.Play("Base Layer.meltingAnim");
                
            }
        }
    }

    public void OnTriggerStay2D(Collider2D obj)
    {
        if (obj.CompareTag("Teleporter"))
        {
            currentTeleporter = obj.gameObject;
            
        }
    }

    public void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.CompareTag("Teleporter"))
        {
            if (obj.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
}
