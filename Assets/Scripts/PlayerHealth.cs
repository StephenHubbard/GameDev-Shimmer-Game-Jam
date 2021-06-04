using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] heartsArray;
    [SerializeField] private int currentHealth = 3;
    [SerializeField] private float knockbackDuration = 1f;
    [SerializeField] private float knockbackPower = 10f;
    [SerializeField] private GameObject menuContainer;
    [SerializeField] private AudioClip playerHitSFX;

    private Animator myAnimator;
    private Rigidbody2D rb;

    private void Awake() {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayerHit(GameObject enemyObj) {

        if (GetComponent<PlayerMovement>().isDead) { return; }

        AudioSource.PlayClipAtPoint(playerHitSFX, transform.position, .4f);
        myAnimator.SetTrigger("Hit");
        currentHealth--;
        UpdateHealth();

        if (currentHealth <= 0) {
            PlayerDeath();
        }

        StartCoroutine(Knockback(knockbackDuration, knockbackPower, enemyObj.transform));
    }

    private IEnumerator Knockback(float knockbackDuration, float knockbackPower, Transform obj) {
        float timer = 0;

        while (knockbackDuration > timer) {
            timer += Time.deltaTime;
            Vector2 direction = (obj.transform.position - this.transform.position).normalized;
            rb.AddForce(-direction * knockbackPower);
        }

        yield return 0;
    }


    private void UpdateHealth() {
        if (currentHealth == 1) {
            heartsArray[0].gameObject.SetActive(true);
            heartsArray[1].gameObject.SetActive(false);
            heartsArray[2].gameObject.SetActive(false);
        }
        else if (currentHealth == 2) {
            heartsArray[0].gameObject.SetActive(true);
            heartsArray[1].gameObject.SetActive(true);
            heartsArray[2].gameObject.SetActive(false);
        }
        else if (currentHealth == 3) {
            heartsArray[0].gameObject.SetActive(true);
            heartsArray[1].gameObject.SetActive(true);
            heartsArray[2].gameObject.SetActive(true);
        }
        else if (currentHealth == 0) {
            heartsArray[0].gameObject.SetActive(false);
            heartsArray[1].gameObject.SetActive(false);
            heartsArray[2].gameObject.SetActive(false);
        } 
    }

    private void PlayerDeath() {
        myAnimator.SetTrigger("Die");
        GetComponent<PlayerMovement>().isDead = true;
        menuContainer.SetActive(true);
    }
}
