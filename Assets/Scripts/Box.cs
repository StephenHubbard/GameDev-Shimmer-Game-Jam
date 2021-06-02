using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] private Animator myAnimator;
    [SerializeField] private int hitsToDestroy = 3;
    [SerializeField] private GameObject boxDestroyVFX;

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
            Destroy(gameObject);
        }
    }
}
