using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MutationInfo
{
    private Animator anim;
    public float attackTime;
    public float startTimeAttack;

    public Transform attackLocation;
    public float attackRange;
    public LayerMask enemies;
    public float coolDown;
    private GameObject player;

    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();

        float magnifier = 1;
        for (int i= 0; i < player.GetComponent<PlayerControls>().anArrayOfPassives.Length; i++)
        {
            if (player.GetComponent<PlayerControls>().anArrayOfPassives[i].gameObject.GetComponent<MutationInfo>().attackBuff == true)
            {
                positivePower = positivePower + player.GetComponent<PlayerControls>().anArrayOfPassives[i].gameObject.GetComponent<MutationInfo>().positivePower;
                magnifier = magnifier + player.GetComponent<PlayerControls>().anArrayOfPassives[i].gameObject.GetComponent<MutationInfo>().powerMultiplier;
            }
            positivePower = positivePower * magnifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime <= 1)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                
                anim.SetBool("isAttacking", true);
                Collider2D[] damage = Physics2D.OverlapCircleAll(attackLocation.position, attackRange, enemies);
                

                for (int i = 0; i < damage.Length; i++)
                {
                    //Destroy(damage[i].gameObject);
                    damage[i].gameObject.GetComponent<Enemy>().TakeDamage(25);
                }
                attackTime = coolDown;
            }
            //attackTime = startTimeAttack;
        }
        else
        {
            attackTime = attackTime - Time.fixedDeltaTime;
            anim.SetBool("isAttacking", false);
        }
    }

    
}
