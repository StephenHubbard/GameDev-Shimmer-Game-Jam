using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudSpeed : MonoBehaviour
{
    [SerializeField] private Sprite[] cloudSprites;

    private float speed;

    void Start()
    {
        speed = Random.Range(0.1f, 1f);

        ChangeSprite();
        ChangeSize();
    }

    

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void ChangeSprite() {
        int randomNum = Random.Range(0, 4);

        GetComponent<SpriteRenderer>().sprite = cloudSprites[randomNum];
    }

    private void ChangeSize() {
        transform.localScale = new Vector3(Random.Range(1f, 2f), Random.Range(.8f, 1.5f), 0);
    }
}
