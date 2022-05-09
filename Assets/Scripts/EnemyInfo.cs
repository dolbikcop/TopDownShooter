using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyInfo : MonoBehaviour
{
    public GameObject startScreen;
    public GameObject wormScreen;
    public GameObject trojanScreen;

    private GameObject screen;

    private void Start()
    {
        screen = Instantiate(startScreen, transform.position, Quaternion.identity);
        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale == 0f)
        {
            Time.timeScale = 1f;
            Destroy(screen);            
        }
    }

    private bool isWorm, isTrojan;

    private void OnTriggerEnter2D(Collider2D col)
    {
        Enemy e = col.gameObject.GetComponent<Enemy>();
        if (e)
        {
            if (e.gameObject.tag == "Worm" && !isWorm)
            {
                Time.timeScale = 0f;
                screen = Instantiate(wormScreen, transform.position, Quaternion.identity);
                isWorm = true;
            } else if (e.gameObject.tag == "Trojan" && !isTrojan)
            {
                Time.timeScale = 0f;
                screen = Instantiate(trojanScreen, transform.position, Quaternion.identity);
                isTrojan = true;
            }
            
        }
    }
}
