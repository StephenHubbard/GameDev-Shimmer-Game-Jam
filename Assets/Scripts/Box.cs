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
    [SerializeField] private float timeTillDetonate = 20f;

    void Start()
    {
        StartCoroutine(TimedDetonate());
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

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            StartDetonate();
        }
    }

    public void BlowUp() {
        Instantiate(boxDestroyVFX, transform.position, transform.rotation);
        Instantiate(enemyPrefab, transform.position, enemyPrefab.transform.rotation);
        Destroy(gameObject);
    }

    public void StartDetonate() {
        myAnimator.SetBool("Landed", true);
    }

    private IEnumerator TimedDetonate() {
        yield return new WaitForSeconds(timeTillDetonate);
        StartDetonate();
    }
}
