using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] myPrefabs;

    private Vector3 spawnPosition0 = new Vector3(40, 0, 0);
    private Vector3 spawnPosition1 = new Vector3(157.8f, 9.5f, 4.0f);

    private float startDelay = 2.0f;
    private float repeatRate = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
        InvokeRepeating("SpawnBackground", 0.0f, 11.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        Instantiate(myPrefabs[0], spawnPosition0, myPrefabs[0].transform.rotation);
    }

    void SpawnBackground()
    {
        Instantiate(myPrefabs[1], spawnPosition1, myPrefabs[1].transform.rotation);
    }
}
