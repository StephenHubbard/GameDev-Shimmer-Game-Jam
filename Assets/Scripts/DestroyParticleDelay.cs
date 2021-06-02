﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleDelay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyGameObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator DestroyGameObject() {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
