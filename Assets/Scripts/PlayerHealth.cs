using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Image[] heartsArray;
    [SerializeField] private int currentHealth = 3;

    private Animator myAnimator;

    private void Awake() {
        myAnimator = GetComponent<Animator>();
    }

    public void PlayerHit() {
        myAnimator.SetTrigger("Hit");
        currentHealth--;
        UpdateHealth();

        if (currentHealth <= 0) {
            PlayerDeath();
        }
    }

    private void Update() {
        
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

    }
}
