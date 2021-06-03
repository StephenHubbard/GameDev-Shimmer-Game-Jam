using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pudding : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            IncreaseAmmo();
            Destroy(gameObject);
        }
    }

    private void IncreaseAmmo() {
        FindObjectOfType<Weapon>().currentAmmo += 10;
    }
}
