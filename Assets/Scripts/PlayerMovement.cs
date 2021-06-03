using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	[SerializeField] CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;

  public bool isDead = false;

	private Animator myAnimator;

	private void Awake() {
		myAnimator = GetComponent<Animator>();
	}
	
	void Update () {

		if (isDead) { 
			horizontalMove = 0f;
			return; 
		}

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (horizontalMove > 0 || horizontalMove < 0) {
			myAnimator.SetBool("isRunning", true);
		}
		else {
			myAnimator.SetBool("isRunning", false);
		}

		if (Input.GetButtonDown("Jump"))
			{
				jump = true;
			}
    }

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

}