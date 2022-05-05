using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale == 0f)
            Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<Enemy>())
            Time.timeScale = 0f;
    }
}
