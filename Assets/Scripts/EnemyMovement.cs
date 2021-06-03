using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] CharacterController2D controller;

	float horizontalMove = 5f;
	bool jump = false;

    void Start()
    {
        StartCoroutine(ChangeDirection());
        StartCoroutine(Jump());
    }

    void Update()
    {
        
    }

    void FixedUpdate ()
	{
		controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
		jump = false;
	}

    private IEnumerator ChangeDirection() {

        if (Random.value < .5f) {
            horizontalMove = 5f;
        }
        else {
            horizontalMove = -5f;
        }

        yield return new WaitForSeconds(Random.Range(2f, 5f));
        StartCoroutine(ChangeDirection());
    }

    private IEnumerator Jump() {
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        horizontalMove *= 2.5f;
        jump = true;
        yield return new WaitForSeconds(Random.Range(2f, 5f));
        horizontalMove = 5f;
        StartCoroutine(Jump());
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<PlayerHealth>().PlayerHit();
        }
    }
}
