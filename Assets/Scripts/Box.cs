using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;
    [SerializeField] private int hitsToDestroy = 3;
    [SerializeField] private GameObject boxDestroyVFX;
    [SerializeField] private GameObject puddingPrefab;
    [SerializeField] private GameObject enemyPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void boxHit() {
        hitsToDestroy--;
        myAnimator.SetTrigger("Hit");
        if (hitsToDestroy <= 0) {
            Instantiate(boxDestroyVFX, transform.position, transform.rotation);

            if (Random.value < .5f) {
                Instantiate(puddingPrefab, transform.position, transform.rotation);
            }
            else {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
            }

            Destroy(gameObject);
        }
    }
}
