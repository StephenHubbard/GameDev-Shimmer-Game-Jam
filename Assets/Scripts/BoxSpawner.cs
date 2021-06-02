using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;

    private bool levelIsActive = true;

    [SerializeField] private int numOfBoxesToSpawn = 10;

    void Start()
    {
        StartCoroutine(SpawnBox());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnBox() {

        Vector2 randomSpawnLocation = new Vector2(transform.position.x + ReturnRandomNum(), transform.position.y);
        
        Instantiate(boxPrefab, randomSpawnLocation, transform.rotation);

        yield return new WaitForSeconds(1f);

        numOfBoxesToSpawn--;
        if (numOfBoxesToSpawn <= 0) {
            levelIsActive = false;
        }
        else {
            StartCoroutine(SpawnBox());
        }


    }

    private int ReturnRandomNum() {
        return Random.Range(-8, 9);
    }
}
