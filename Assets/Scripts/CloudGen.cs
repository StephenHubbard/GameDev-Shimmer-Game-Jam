using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudGen : MonoBehaviour
{
    [SerializeField] private GameObject leftSide;
    [SerializeField] private GameObject rightSide;
    [SerializeField] private GameObject cloudPrefab;

    private void Start() {
        StartCoroutine(SpawnCloud());
    }

    private IEnumerator SpawnCloud() {
        int randomNum = Random.Range(-5, 6);
        Vector2 cloudSpawnPos = new Vector2(leftSide.transform.position.x, leftSide.transform.position.y + randomNum);
        Instantiate(cloudPrefab, cloudSpawnPos, transform.rotation);
        yield return new WaitForSeconds(6f);
        StartCoroutine(SpawnCloud());
    }

}
