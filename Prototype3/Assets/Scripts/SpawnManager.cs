using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] myPrefabs;

    private Vector3 spawnPosition0 = new Vector3(40, 0, 0);

    //Obstacle start delay and repeat rate
    private float startDelayO = 2.0f;
    private float repeatRateO = 2.0f;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelayO, repeatRateO);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        int obstacleIndex = Random.Range(0, myPrefabs.Length);
        if (!playerControllerScript.gameOver)
        {
            Instantiate(myPrefabs[obstacleIndex], spawnPosition0, myPrefabs[obstacleIndex].transform.rotation);
        }
    }
}
