using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fighting : MonoBehaviour
{
    public float speed;
    public int damage = 1;
    private float startSpeed;

    private Transform player;
    void Start()
    {
        player = DataManager.player;
        startSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
        if (ph)
        {
            ph.TakeDamage(damage);
            speed = 0;
        }

        speed = startSpeed;
    }
}
