using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops : MonoBehaviour
{

    public List<GameObject> box;

    public List<Transform> spawnLocations;

    public void Start()
    {
        StartCoroutine(drop());   
    }

    IEnumerator drop()
    {
        yield return new WaitForSeconds(10);

        int pom = Random.Range(0, spawnLocations.Count);
        Instantiate(box[Random.Range(0, 5)], spawnLocations[pom]);

        spawnLocations.Remove(spawnLocations[pom]);

        StartCoroutine(drop());
    }
}
