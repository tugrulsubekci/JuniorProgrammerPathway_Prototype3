using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] myPrefabs;

    private Vector3 spawnPosition0 = new Vector3(40, 0, 0);
    private Vector3 spawnPosition1 = new Vector3(157.8f, 9.5f, 4.0f);

    //Obstacle start delay and repeat rate
    private float startDelayO = 2.0f;
    private float repeatRateO = 2.0f;

    // Background start delay and repeat rate
    private float startDelayB = 0.0f;
    private float repeatRateB = 5.6f;

    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelayO, repeatRateO);
        InvokeRepeating("SpawnBackground", startDelayB, repeatRateB);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(myPrefabs[0], spawnPosition0, myPrefabs[0].transform.rotation);
        }

    }

    void SpawnBackground()
    {
        if (!playerControllerScript.gameOver)
        {
            Instantiate(myPrefabs[1], spawnPosition1, myPrefabs[1].transform.rotation);
        }

    }
}
