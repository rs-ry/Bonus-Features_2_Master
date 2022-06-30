using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    public int setMax = 7;
    int applyMaxToList;
    List<GameObject> onGroundPrefabs = new List<GameObject>();
    public Transform spawnPoint;
    public int spawnInterval;

    void Start()
    {
        applyMaxToList = setMax - 1;
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
        
            if (onGroundPrefabs.Count > applyMaxToList) continue;

            int animalIndex = Random.Range(0, animalPrefabs.Length);

            Vector3 spawnPos = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);

            Vector3 rotation = new Vector3(0, 90, 0);

            var gObj = Instantiate(animalPrefabs[animalIndex], spawnPos, Quaternion.Euler(rotation)) as GameObject;

            onGroundPrefabs.Add(gObj);
        }
    }

    private void Update()
    {
        GameManager.instance.currentlyOnGround = onGroundPrefabs.Count;
    }
}
