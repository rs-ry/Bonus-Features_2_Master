using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int totalOnGround = 7;
    List<Transform> onGroundPrefabs;
    public Transform spawnPoint;

    void Start()
    {
        totalOnGround = 7 - 1;
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(8);

            if (onGroundPrefabs.Count > totalOnGround) continue;

            int animalIndex = Random.Range(0, animalPrefabs.Length);

            Vector3 spawnPos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);

            Vector3 rotation = new Vector3(0, 90, 0);

            var gObj = Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation)) as GameObject;

            onGroundPrefabs.Add(gObj.transform);
        }
    }
}
