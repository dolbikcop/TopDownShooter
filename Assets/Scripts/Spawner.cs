using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoint;
    
    private int rand;
    private int randPosition;
    public float startTimeBtwSpawns;
    private float time;
    
    void Start()
    {
        time = startTimeBtwSpawns;
    }

    void Update()
    {
        if (time <= 0)
        {
            rand = Random.Range(0, enemy.Length);
            randPosition = Random.Range(0, spawnPoint.Length);
            try
            {
                Instantiate(enemy[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            }
            catch {}

            time = startTimeBtwSpawns;
        }
        else
        {
            time -= Time.deltaTime;
        }
    }
}
