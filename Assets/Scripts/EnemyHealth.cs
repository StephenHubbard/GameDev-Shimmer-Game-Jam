using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int currentHealth = 3;
    
    [SerializeField] private GameObject enemyDestroyVFX;

    [SerializeField] private Animator myAnimator;

    private void Awake() {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnemyHit() {
        currentHealth--;
            myAnimator.SetTrigger("Hit");
            if (currentHealth <= 0) {
                Instantiate(enemyDestroyVFX, transform.position, transform.rotation);
                FindObjectOfType<SlimesKilled>().slimesKilled++;
                Destroy(gameObject);
            }
    }
}
