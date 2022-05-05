using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform[] spawnPoint;
    
    private int rand;
    private int randPosition;
    public float startTimeBtwSpawns;
    private float time;
    
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        //time = startTimeBtwSpawns;
        //Debug.Log(startTimeBtwSpawns);
    }

    //void Update()
    //{
    //    if (time <= 0)
    //    {
    //        var rand = Random.Range(0, enemies.Length);
    //        var randPosition = Random.Range(0, spawnPoint.Length);
    //        Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
    //        time = startTimeBtwSpawns;
    //    }
    //    else
    //    {
    //        time -= Time.deltaTime;
    //    }
    //}

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            var rand = Random.Range(0, enemies.Length);
            var randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemies[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            yield return new WaitForSeconds(3f);
        }
    }
}
