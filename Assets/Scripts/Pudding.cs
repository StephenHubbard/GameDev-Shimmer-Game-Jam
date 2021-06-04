using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pudding : MonoBehaviour
{
    [SerializeField] private AudioClip eatSFX;

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            IncreaseAmmo();
            AudioSource.PlayClipAtPoint(eatSFX, transform.position);
            Destroy(gameObject);
        }
    }

    private void IncreaseAmmo() {
        FindObjectOfType<Weapon>().currentAmmo += 10;
    }
}
