using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    int randSpawn;
    public GameObject ballPrefab;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;
    private PlayerController playerControllerScript;
    // Start is called before the first frame update
    void Start()

    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void SpawnRandomBall()

    {
        if (playerControllerScript.gameOver == false)
        {
            randSpawn = Random.Range(0, spawnPoints.Length);
            Instantiate(ballPrefab, spawnPoints[randSpawn].position, ballPrefab.transform.rotation);
        }
    }
    }
