using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask whatIsSolid;

    public GameObject destroyEffect;

    private bool isFacingRightWhenShot;

    private CharacterController2D characterController2D;

    private void Awake() {
        characterController2D = FindObjectOfType<PlayerMovement>().GetComponent<CharacterController2D>();
    }

    private void Start()
    {

        if (characterController2D.m_FacingRight) {
            isFacingRightWhenShot = true;
        }
        else {
            isFacingRightWhenShot = false;
        }
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null) {
            if (hitInfo.collider.CompareTag("Box")) {
                hitInfo.collider.GetComponent<Box>().boxHit();
                DestroyProjectile();
            }
            if (hitInfo.collider.CompareTag("Enemy")) {
                hitInfo.collider.GetComponent<EnemyHealth>().EnemyHit();
                DestroyProjectile();
            }
        }

        if (isFacingRightWhenShot) {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    void DestroyProjectile() {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
