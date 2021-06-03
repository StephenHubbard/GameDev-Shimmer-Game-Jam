using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour {

    [SerializeField] public int currentAmmo = 50;
    [SerializeField] private Slider puddingSlider;

    public float offset;

    public GameObject projectile;
    // public GameObject shotEffect;
    public Transform shotPoint;
    // public Animator camAnim;

    private float timeBtwShots;
    public float startTimeBtwShots;


    private CharacterController2D characterController2D;

    private void Awake() {
        characterController2D = FindObjectOfType<PlayerMovement>().GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        FollowMouse();
        UpdatePuddingSlider();
    }

    private void FollowMouse()
    {
        if (characterController2D.m_FacingRight)
        {
        offset = 0;
        }
        else
        {
        offset = 180;
        }
        // Handles the weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwShots <= 0)
        {
        if (Input.GetMouseButton(0) && currentAmmo >= 1)
        {
            // Instantiate(shotEffect, shotPoint.position, Quaternion.identity);
            // camAnim.SetTrigger("shake");
            Instantiate(projectile, shotPoint.position, transform.rotation);
            currentAmmo--;
            timeBtwShots = startTimeBtwShots;
        }
        }
        else
        {
        timeBtwShots -= Time.deltaTime;
        }
    }

    private void UpdatePuddingSlider() {
        puddingSlider.value = currentAmmo;
        MaxAmmo();
    }

    private void MaxAmmo() {
        if (currentAmmo > 50) {
            currentAmmo = 0;
        }
    }
}
