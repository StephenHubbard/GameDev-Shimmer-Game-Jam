using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] private GameObject boxPrefab;
    [SerializeField] private GameObject puddingPrefab;

    [SerializeField] private float timeBetweenSpawn = 5f;
    [SerializeField] private float puddingSpawnTime = 8f;

    private bool levelIsActive = true;

    void Start()
    {
        StartCoroutine(SpawnBox());
        StartCoroutine(SpawnPudding());
    }

    void Update()
    {
        
    }

    private IEnumerator SpawnBox() {
        Vector2 randomSpawnLocation = new Vector2(transform.position.x + ReturnRandomNum(), transform.position.y);
        Instantiate(boxPrefab, randomSpawnLocation, transform.rotation);
        yield return new WaitForSeconds(timeBetweenSpawn);
        timeBetweenSpawn *= .95f;
        if (timeBetweenSpawn <= .5f) {
            timeBetweenSpawn = .5f;
        }
        StartCoroutine(SpawnBox());
    }

    private int ReturnRandomNum() {
        return Random.Range(-24, 25);
    }

    private IEnumerator SpawnPudding(){
        yield return new WaitForSeconds(puddingSpawnTime);
        Vector2 randomSpawnLocation = new Vector2(transform.position.x + ReturnRandomNum(), transform.position.y);
        Instantiate(puddingPrefab, randomSpawnLocation, transform.rotation);
        StartCoroutine(SpawnPudding());
    }
}
