using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

	public CharacterControl controller;
	public Animator animator;
	private Rigidbody2D rb;
	public float runSpeed = 40f;
	

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;
	public GameObject[] players;
	

	void Start()
    {
		

		rb = gameObject.GetComponent<Rigidbody2D>();

    }
	// Update is called once per frame
	void Update()
	{
		

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		

		rb.velocity = new Vector2(horizontalMove * runSpeed, rb.velocity.y);

		
		if(horizontalMove != 0)
        {
			animator.SetBool("isWalking", true);
        }
		else
        {
			animator.SetBool("isWalking", false);
		}

        
	}


	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}
}
