using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
    public Transform[] spawnpoints;
    public GameObject[] enemies;

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float minTimeBtwSpawns;
    public float decrease;

    public GameObject player;
    public Text scoreDisplay;
    float score = 0;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (timeBtwSpawns <= 0)
            {
                //spawn enemy
                Transform randomSpawnPoint = spawnpoints[Random.Range(0, spawnpoints.Length)];
                GameObject randomEnemy = enemies[Random.Range(0, enemies.Length)];

                if (startTimeBtwSpawns > minTimeBtwSpawns)
                {
                    startTimeBtwSpawns -= decrease;
                }
                //spawn enemy at random spawn points
                Instantiate(randomEnemy, randomSpawnPoint.position, Quaternion.identity);
                score++;
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;

            }
            scoreDisplay.text = "Score: " + score.ToString();

        }
    }
}
